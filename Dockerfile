FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY NetGearLTE/*.csproj ./NetGearLTE/
WORKDIR /app/NetGearLTE
RUN dotnet restore

WORKDIR /app/
COPY NetGearLTE.Library/*.csproj ./NetGearLTE.Library/
WORKDIR /app/NetGearLTE.Library
RUN dotnet restore

WORKDIR /app/COPY NetGearLTE.Library/. ./NetGearLTE.Library/
COPY NetGearLTE/ NetGearLTE/ NetGearLTE.Library/ NetGearLTE.Library/

WORKDIR /app/NetGearLTE
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/NetGearLTE/out ./
ENTRYPOINT ["dotnet", "NetGearLTE.dll"]