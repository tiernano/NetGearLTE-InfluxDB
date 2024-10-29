using Flurl.Http;
using Serilog;
using System;
using System.Text.RegularExpressions;

namespace NetGearLTE.Library
{
    public class Client
    {
        private readonly IFlurlClient mFlurlClient;
        private CookieJar jar;

        public Client(string BaseURL, string Password)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("consoleapp.log")
            .WriteTo.Console()
            .CreateLogger();

            mFlurlClient = new FlurlClient(BaseURL);
            mFlurlClient.WithHeader("Content-Type", "application/x-www-form-urlencoded");
            mFlurlClient.WithHeader("Accept", "application/json");

            mFlurlClient.BeforeCall(call => Log.Logger.Debug($"Calling Netgear Url {call.Request.Url}"));
            mFlurlClient.OnError(call =>
                Log.Logger.Error($"Error calling Netgear: {call.RequestBody} -  {call.Exception}"));
            mFlurlClient.AfterCall(call =>
                Log.Logger.Debug($"called Netgear with {call.Response.StatusCode} in {call.Duration}"));
             

            string response = mFlurlClient.Request().WithCookies(out jar).GetStringAsync().GetAwaiter().GetResult();

            Regex regex = new Regex("name=\"token\" value=\"(.*?)\"");

            Match match = regex.Match(response);

            if (match.Success)
            {
                string token = match.Groups[1].Value;
                Log.Logger.Debug($"Got a match. found {token}");

                var result = mFlurlClient.Request("Forms/config").WithCookies(jar).SetQueryParam("session.password", Password).SetQueryParam("token", token)
                    .GetAsync().GetAwaiter().GetResult();

            }
            else
            {
                throw new Exception("Did not get token from URL");
            }
        }

        public Model GetModel()
        {
            return mFlurlClient.Request("/api/model.json").WithCookies(jar).SetQueryParam("internalapi", "1").GetJsonAsync<Model>().GetAwaiter().GetResult();
        }
    }
}
