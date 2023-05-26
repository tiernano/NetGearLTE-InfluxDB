# NetGearLTE

A small .NET core application that queries a Netgear LTE Modem (tested on a [LB2120](https://www.netgear.ie/home/products/mobile-broadband/lte-modems/LB2120.aspx), but may work on others). 
It gets the following info and puts it into [InfluxDB](https://www.influxdata.com/):

 
## Bandwidth details

* "tx", wwan.dataTransferredTx },
* "rx",  wwan.dataTransferredRx},
* "total", wwan.dataTransferred },
* "billingCycleLimit",wwan.dataUsage.generic.billingCycleLimit },
* "dataTransferred", wwan.dataUsage.generic.dataTransferred },
* "billingCycleRemainder", wwan.dataUsage.generic.billingCycleRemainder}

## Signal stuff

* "rssi", wwan.signalStrength.rssi 
* "bars", wwan.signalStrength.bars 
* "rscp", wwan.signalStrength.rscp 
* "ecio", wwan.signalStrength.ecio 
* "rsrp", wwan.signalStrength.rsrp 
* "rsrq", wwan.signalStrength.rsrq 
* "sinr", wwan.signalStrength.sinr 
* "quality", wwanadv.radioQuality


