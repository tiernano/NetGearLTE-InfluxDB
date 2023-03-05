using Flurl.Http;
using Serilog;
using System;
using System.Text.RegularExpressions;

namespace NetGearLTE.Library
{
    public class Client
    {
        private readonly IFlurlClient mFlurlClient;

        public Client(string BaseURL, string Password)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("consoleapp.log")
            .WriteTo.Console()
            .CreateLogger();

            var jar = new CookieJar();

            mFlurlClient = new FlurlClient(BaseURL).Configure(settings =>
            {
                settings.BeforeCall = call => Log.Logger.Debug($"Calling Netgear Url {call.Request.RequestUri}");
                settings.OnError = call => Log.Logger.Error($"Error calling Netgear: {call.RequestBody} -  {call.Exception}");
                settings.AfterCall = call =>
                    Log.Logger.Debug($"called Netgear with {call.HttpStatus} in {call.Duration}");
                settings.WithCookies(out var jar);
            });

            string response = mFlurlClient.Request().GetStringAsync().GetAwaiter().GetResult();

            Regex regex = new Regex("name=\"token\" value=\"(.*?)\"");

            Match match = regex.Match(response);

            if (match.Success)
            {

                string token = match.Groups[1].Value;
                Log.Logger.Debug($"Got a match. found {token}");

                var result = mFlurlClient.Request("Forms/config").SetQueryParam("session.password", Password).SetQueryParam("token", token)
                    .GetAsync().GetAwaiter().GetResult();

            }
            else
            {
                throw new Exception("Did not get token from URL");
            }
        }

        public Model GetModel()
        {
            return mFlurlClient.Request("/api/model.json").SetQueryParam("internalapi", "1").GetJsonAsync<Model>().GetAwaiter().GetResult();
        }
    }
}
