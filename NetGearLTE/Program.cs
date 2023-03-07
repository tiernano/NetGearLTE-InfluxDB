using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using ByteSizeLib;
using Flurl;
using Flurl.Http;
using InfluxDB.Collector;
using Serilog;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace NetGearLTE
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

            Settings settings = config.GetRequiredSection("Settings").Get<Settings>();



            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("consoleapp.log")
                .WriteTo.Console()
                .CreateLogger();

            string baseUrl = settings.netgear.url;
            string password = settings.netgear.password;

            NetGearLTE.Library.Client client = new Library.Client(baseUrl, password);


            Log.Logger.Debug("Calling out to telegraf");
            Metrics.Collector = new CollectorConfiguration()
                .Tag.With("host", Environment.GetEnvironmentVariable("COMPUTERNAME"))
                .Batch.AtInterval(TimeSpan.FromSeconds(30))
                .WriteTo.InfluxDB(settings.influxdb.url, settings.influxdb.database)
                .CreateCollector();


            while (true)
            {
                try
                {
                    var model = client.GetModel();

                    Log.Logger.Debug($"WANIP: {model.wwan.IP} SMS count: {model.sms.msgCount} Unread: {model.sms.unreadMsgs}");
                    Log.Logger.Debug($"model.wwan.dataTransferred: {model.wwan.dataTransferred} ");
                    Log.Logger.Debug($"model.wwan.dataUsage.generic.billingCycleLimit: {model.wwan.dataUsage.generic.billingCycleLimit} ");
                    Log.Logger.Debug($"model.wwan.dataUsage.generic.dataTransferred: {model.wwan.dataUsage.generic.dataTransferred} ");
                    Log.Logger.Debug($"model.wwan.dataTransferredTx: {model.wwan.dataTransferredTx} ");
                    Log.Logger.Debug($"model.wwan.dataTransferredRx: {model.wwan.dataTransferredRx} ");

                    long tx = long.Parse(model.wwan.dataTransferredTx);
                    long rx = long.Parse(model.wwan.dataTransferredRx);
                    long cycleRemander = long.Parse(model.wwan.dataUsage.generic.billingCycleRemainder);


                    Metrics.Write("ltedata",
                        new Dictionary<string, object>
                        {
                        { "tx", tx },
                        { "rx",  rx},
                        { "total", model.wwan.dataTransferred },
                        { "billingCycleLimit",model.wwan.dataUsage.generic.billingCycleLimit },
                        { "dataTransferred", model.wwan.dataUsage.generic.dataTransferred },
                        { "billingCycleRemainder", cycleRemander}
                        });
                    Log.Logger.Debug("Wrote Data Trasfer Data");

                    Metrics.Write("signalStrength",
                        new Dictionary<string, object>
                        {
                        { "rssi", model.wwan.signalStrength.rssi },
                        { "bars", model.wwan.signalStrength.bars },
                        {"rscp", model.wwan.signalStrength.rscp },
                        {"ecio", model.wwan.signalStrength.ecio },
                        {"rsrp", model.wwan.signalStrength.rsrp },
                        {"rsrq", model.wwan.signalStrength.rsrq },
                        {"sinr", model.wwan.signalStrength.sinr },
                        {"quality", model.wwanadv.radioQuality }
                        });

                    Log.Logger.Debug("Wrote Signnal info");

                    Log.Logger.Debug("waiting 30 seconds");
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex, "Error when either talking to modem or writing to InfluxDB");
                }

                Thread.Sleep(30000);

            }
        }
    }


    public class Settings
    {
        public Netgear netgear { get; set; }
        public Influxdb influxdb { get; set; }
    }

    public class Netgear
    {
        public string url { get; set; }
        public string password { get; set; }
    }

    public class Influxdb
    {
        public string url { get; set; }
        public string database { get; set; }
    }

}
