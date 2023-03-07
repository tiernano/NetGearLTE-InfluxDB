FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app
COPY NetGearLTE/*.csproj ./NetGearLTE/
WORKDIR /app/NetGearLTE
RUN ls
RUN dotnet restore

WORKDIR /app/
COPY NetGearLTE.Library/*.csproj ./NetGearLTE.Library/
WORKDIR /app/NetGearLTE.Library
RUN ls 
RUN dotnet restore

WORKDIR /app/
COPY NetGearLTE/. ./NetGearLTE/
COPY NetGearLTE.Library/. ./NetGearLTE.Library/

WORKDIR /app/NetGearLTE
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/NetGearLTE/out ./
ENTRYPOINT ["dotnet", "NetGearLTE.dll"]