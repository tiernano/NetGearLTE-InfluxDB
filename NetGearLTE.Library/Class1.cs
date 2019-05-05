using Flurl.Http;
using NLog;
using System;
using System.Text.RegularExpressions;

namespace NetGearLTE.Library
{
    public class Client
    {
        private readonly Logger mLogger;
        private readonly IFlurlClient mFlurlClient;

        public Client(string BaseURL, string Password)
        {
            mLogger = LogManager.GetCurrentClassLogger();

            mFlurlClient = new FlurlClient(BaseURL).EnableCookies().Configure(settings =>
            {
                settings.BeforeCall = call => mLogger.Debug($"Calling Netgear Url {call.Request.RequestUri}");
                settings.OnError = call => mLogger.Error($"Error calling Netgear: {call.RequestBody} -  {call.Exception}");
                settings.AfterCall = call =>
                    mLogger.Debug($"called Netgear with {call.HttpStatus} in {call.Duration}");
            });

            string responce = mFlurlClient.Request().GetStringAsync().GetAwaiter().GetResult();

            Regex regex = new Regex("name=\"token\" value=\"(.*?)\"");

            Match match = regex.Match(responce);

            if (match.Success)
            {

                string token = match.Groups[1].Value;
                mLogger.Debug($"Got a match. found {token}");

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
