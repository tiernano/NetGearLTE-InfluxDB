using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using ByteSizeLib;
using Flurl;
using Flurl.Http;
using InfluxDB.Collector;
using NLog;

namespace NetGearLTE
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger mLogger = LogManager.GetCurrentClassLogger();


            string baseUrl = "http://192.168.5.1";
            string password = "qL6rc4Eo";

            NetGearLTE.Library.Client client = new Library.Client(baseUrl, password);

           
            mLogger.Debug("Calling out to telegraf");
            Metrics.Collector = new CollectorConfiguration()
                .Tag.With("host", Environment.GetEnvironmentVariable("COMPUTERNAME"))
                .Batch.AtInterval(TimeSpan.FromSeconds(30))
                .WriteTo.InfluxDB("http://192.168.1.119:8086", "telegraf")
                .CreateCollector();               


            while (true)
            {
                try
                {
                    var model = client.GetModel();

                    mLogger.Debug($"WANIP: {model.wwan.IP} SMS count: {model.sms.msgCount} Unread: {model.sms.unreadMsgs}");
                    mLogger.Debug($"model.wwan.dataTransferred: {model.wwan.dataTransferred} ");
                    mLogger.Debug($"model.wwan.dataUsage.generic.billingCycleLimit: {model.wwan.dataUsage.generic.billingCycleLimit} ");
                    mLogger.Debug($"model.wwan.dataUsage.generic.dataTransferred: {model.wwan.dataUsage.generic.dataTransferred} ");
                    mLogger.Debug($"model.wwan.dataTransferredTx: {model.wwan.dataTransferredTx} ");
                    mLogger.Debug($"model.wwan.dataTransferredRx: {model.wwan.dataTransferredRx} ");

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
                    mLogger.Debug("Wrote Data Trasfer Data");

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

                    mLogger.Debug("Wrote Signnal info");

                    mLogger.Debug("waiting 30 seconds");
                }
                catch(Exception ex)
                {
                    mLogger.Error(ex, "Error when either talking to modem or writing to InfluxDB");
                }

                Thread.Sleep(30000);

            }
        }
    }
}
