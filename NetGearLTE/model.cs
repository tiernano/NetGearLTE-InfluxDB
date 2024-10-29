namespace NetGearLTE
{
    public class Rootobject
    {
        public Custom custom { get; set; }
        public Webd webd { get; set; }
        public Lcd lcd { get; set; }
        public Sim sim { get; set; }
        public Sms sms { get; set; }
        public Session session { get; set; }
        public General general { get; set; }
        public Power power { get; set; }
        public Wwan wwan { get; set; }
        public Wwanadv wwanadv { get; set; }
        public Wifi wifi { get; set; }
        public Router router { get; set; }
        public Fota fota { get; set; }
        public Failover failover { get; set; }
        public Eventlog eventlog { get; set; }
        public Ui ui { get; set; }
    }

    public class Custom
    {
        public bool AtTcpEnable { get; set; }
        public int end { get; set; }
    }

    public class Webd
    {
        public string adminPassword { get; set; }
        public bool ownerModeEnabled { get; set; }
        public bool hideAdminPassword { get; set; }
        public string end { get; set; }
    }

    public class Lcd
    {
        public string end { get; set; }
    }

    public class Sim
    {
        public Pin pin { get; set; }
        public Puk puk { get; set; }
        public Mep mep { get; set; }
        public string phoneNumber { get; set; }
        public string iccid { get; set; }
        public string imsi { get; set; }
        public string SPN { get; set; }
        public string status { get; set; }
        public string end { get; set; }
    }

    public class Pin
    {
        public string mode { get; set; }
        public int retry { get; set; }
        public string end { get; set; }
    }

    public class Puk
    {
        public int retry { get; set; }
    }

    public class Mep
    {
    }

    public class Sms
    {
        public bool ready { get; set; }
        public bool sendEnabled { get; set; }
        public bool sendSupported { get; set; }
        public bool alertSupported { get; set; }
        public bool alertEnabled { get; set; }
        public string alertNumList { get; set; }
        public Alertcfglist[] alertCfgList { get; set; }
        public int unreadMsgs { get; set; }
        public int msgCount { get; set; }
        public Msg[] msgs { get; set; }
        public Tran[] trans { get; set; }
        public Sendmsg[] sendMsg { get; set; }
        public string end { get; set; }
    }

    public class Alertcfglist
    {
        public string category { get; set; }
        public bool enabled { get; set; }
    }

    public class Msg
    {
        public string id { get; set; }
        public string rxTime { get; set; }
        public string text { get; set; }
        public string sender { get; set; }
        public bool read { get; set; }
    }

    public class Tran
    {
    }

    public class Sendmsg
    {
    }

    public class Session
    {
        public string userRole { get; set; }
        public string lang { get; set; }
        public string secToken { get; set; }
    }

    public class General
    {
        public string defaultLanguage { get; set; }
        public string PRIid { get; set; }
        public string genericResetStatus { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string HWversion { get; set; }
        public string FWversion { get; set; }
        public string appVersion { get; set; }
        public string buildDate { get; set; }
        public string BLversion { get; set; }
        public string PRIversion { get; set; }
        public string IMEI { get; set; }
        public string SVN { get; set; }
        public string MEID { get; set; }
        public string ESN { get; set; }
        public string FSN { get; set; }
        public bool activated { get; set; }
        public string webAppVersion { get; set; }
        public bool HIDenabled { get; set; }
        public bool TCAaccepted { get; set; }
        public bool LEDenabled { get; set; }
        public bool showAdvHelp { get; set; }
        public string keyLockState { get; set; }
        public int devTemperature { get; set; }
        public int verMajor { get; set; }
        public int verMinor { get; set; }
        public string environment { get; set; }
        public int currTime { get; set; }
        public int timeZoneOffset { get; set; }
        public string deviceName { get; set; }
        public bool useMetricSystem { get; set; }
        public string factoryResetStatus { get; set; }
        public bool setupCompleted { get; set; }
        public bool languageSelected { get; set; }
        public Systemalertlist[] systemAlertList { get; set; }
        public string apiVersion { get; set; }
        public string companyName { get; set; }
        public string configURL { get; set; }
        public string profileURL { get; set; }
        public string pinChangeURL { get; set; }
        public string portCfgURL { get; set; }
        public string portFilterURL { get; set; }
        public string wifiACLURL { get; set; }
        public Supportedlanglist[] supportedLangList { get; set; }
    }

    public class Systemalertlist
    {
    }

    public class Supportedlanglist
    {
        public string id { get; set; }
        public string isCurrent { get; set; }
        public string isDefault { get; set; }
        public string label { get; set; }
        public string token1 { get; set; }
        public string token2 { get; set; }
    }

    public class Power
    {
        public string PMState { get; set; }
        public string SmState { get; set; }
        public Autooff autoOff { get; set; }
        public Standby standby { get; set; }
        public Autoon autoOn { get; set; }
        public int buttonHoldTime { get; set; }
        public bool deviceTempCritical { get; set; }
        public int resetreason { get; set; }
        public string resetRequired { get; set; }
        public bool lpm { get; set; }
        public string end { get; set; }
    }

    public class Autooff
    {
        public Onusbdisconnect onUSBdisconnect { get; set; }
        public Onidle onIdle { get; set; }
    }

    public class Onusbdisconnect
    {
        public bool enable { get; set; }
        public int countdownTimer { get; set; }
        public string end { get; set; }
    }

    public class Onidle
    {
        public Timer timer { get; set; }
    }

    public class Timer
    {
        public int onAC { get; set; }
        public int onBattery { get; set; }
        public string end { get; set; }
    }

    public class Standby
    {
        public Onidle1 onIdle { get; set; }
    }

    public class Onidle1
    {
        public Timer1 timer { get; set; }
    }

    public class Timer1
    {
        public int onAC { get; set; }
        public int onBattery { get; set; }
        public int onUSB { get; set; }
        public string end { get; set; }
    }

    public class Autoon
    {
        public bool enable { get; set; }
        public string end { get; set; }
    }

    public class Wwan
    {
        public string netScanStatus { get; set; }
        public int inactivityCause { get; set; }
        public string currentNWserviceType { get; set; }
        public int registerRejectCode { get; set; }
        public string netSelEnabled { get; set; }
        public string netRegMode { get; set; }
        public string IPv6 { get; set; }
        public bool roaming { get; set; }
        public string IP { get; set; }
        public string registerNetworkDisplay { get; set; }
        public string RAT { get; set; }
        public Bandregion[] bandRegion { get; set; }
        public string autoconnect { get; set; }
        public Profilelist[] profileList { get; set; }
        public Profile profile { get; set; }
        public Datausage dataUsage { get; set; }
        public bool netManualNoCvg { get; set; }
        public string connection { get; set; }
        public string connectionType { get; set; }
        public string currentPSserviceType { get; set; }
        public Ca ca { get; set; }
        public string connectionText { get; set; }
        public int sessDuration { get; set; }
        public int sessStartTime { get; set; }
        public string dataTransferred { get; set; }
        public string dataTransferredRx { get; set; }
        public string dataTransferredTx { get; set; }
        public Signalstrength signalStrength { get; set; }
    }

    public class Profile
    {
        public string _default { get; set; }
        public string defaultLTE { get; set; }
        public bool promptForApnSelection { get; set; }
        public string end { get; set; }
    }

    public class Datausage
    {
        public Total total { get; set; }
        public Server server { get; set; }
        public int serverDataRemaining { get; set; }
        public int serverDataTransferred { get; set; }
        public int serverDataTransferredIntl { get; set; }
        public string serverDataValidState { get; set; }
        public int serverDaysLeft { get; set; }
        public string serverErrorCode { get; set; }
        public bool serverLowBalance { get; set; }
        public string serverMsisdn { get; set; }
        public string serverRechargeUrl { get; set; }
        public bool dataWarnEnable { get; set; }
        public string prepaidAccountState { get; set; }
        public string accountType { get; set; }
        public Share share { get; set; }
        public Generic generic { get; set; }
    }

    public class Total
    {
        public int lteBillingTx { get; set; }
        public int lteBillingRx { get; set; }
        public int cdmaBillingTx { get; set; }
        public int cdmaBillingRx { get; set; }
        public int gwBillingTx { get; set; }
        public int gwBillingRx { get; set; }
        public int lteLifeTx { get; set; }
        public int lteLifeRx { get; set; }
        public int cdmaLifeTx { get; set; }
        public int cdmaLifeRx { get; set; }
        public int gwLifeTx { get; set; }
        public int gwLifeRx { get; set; }
        public string end { get; set; }
    }

    public class Server
    {
        public string accountType { get; set; }
        public string subAccountType { get; set; }
        public string end { get; set; }
    }

    public class Share
    {
        public bool enabled { get; set; }
        public int dataTransferredOthers { get; set; }
        public string lastSync { get; set; }
        public string end { get; set; }
    }

    public class Generic
    {
        public bool dataLimitValid { get; set; }
        public int usageHighWarning { get; set; }
        public string lastSucceeded { get; set; }
        public int billingDay { get; set; }
        public string nextBillingDate { get; set; }
        public string lastSync { get; set; }
        public string billingCycleRemainder { get; set; }
        public long billingCycleLimit { get; set; }
        public long dataTransferred { get; set; }
        public int dataTransferredRoaming { get; set; }
        public string lastReset { get; set; }
        public string end { get; set; }
    }

    public class Ca
    {
        public string end { get; set; }
    }

    public class Signalstrength
    {
        public int rssi { get; set; }
        public int rscp { get; set; }
        public int ecio { get; set; }
        public int rsrp { get; set; }
        public int rsrq { get; set; }
        public int bars { get; set; }
        public int sinr { get; set; }
        public string end { get; set; }
    }

    public class Bandregion
    {
    }

    public class Profilelist
    {
        public int index { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string apn { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string authtype { get; set; }
        public string ipaddr { get; set; }
        public string type { get; set; }
        public string pdproamingtype { get; set; }
    }

    public class Wwanadv
    {
        public string curBand { get; set; }
        public int radioQuality { get; set; }
        public string country { get; set; }
        public int RAC { get; set; }
        public int LAC { get; set; }
        public string MCC { get; set; }
        public string MNC { get; set; }
        public int MNCFmt { get; set; }
        public int cellId { get; set; }
        public int chanId { get; set; }
        public int primScode { get; set; }
        public int plmnSrvErrBitMask { get; set; }
        public int chanIdUl { get; set; }
        public int txLevel { get; set; }
        public int rxLevel { get; set; }
        public string end { get; set; }
    }

    public class Wifi
    {
        public bool enabled { get; set; }
        public int maxClientSupported { get; set; }
        public int maxClientLimit { get; set; }
        public int maxClientCnt { get; set; }
        public int channel { get; set; }
        public bool hiddenSSID { get; set; }
        public string passPhrase { get; set; }
        public int RTSthreshold { get; set; }
        public int fragThreshold { get; set; }
        public string SSID { get; set; }
        public int clientCount { get; set; }
        public string country { get; set; }
        public Wps wps { get; set; }
        public Guest guest { get; set; }
        public string end { get; set; }
    }

    public class Wps
    {
        public string supported { get; set; }
        public string end { get; set; }
    }

    public class Guest
    {
        public int maxClientCnt { get; set; }
        public bool enabled { get; set; }
        public string SSID { get; set; }
        public string passPhrase { get; set; }
        public bool generatePassphrase { get; set; }
        public bool hiddenSSID { get; set; }
        public int chan { get; set; }
        public DHCP DHCP { get; set; }
    }

    public class DHCP
    {
        public Range range { get; set; }
    }

    public class Range
    {
        public string end { get; set; }
    }

    public class Router
    {
        public string gatewayIP { get; set; }
        public string DMZaddress { get; set; }
        public bool DMZenabled { get; set; }
        public bool forceSetup { get; set; }
        public DHCP1 DHCP { get; set; }
        public string usbMode { get; set; }
        public bool usbNetworkTethering { get; set; }
        public bool portFwdEnabled { get; set; }
        public Portfwdlist[] portFwdList { get; set; }
        public bool portFilteringEnabled { get; set; }
        public string portFilteringMode { get; set; }
        public Portfilterwhitelist[] portFilterWhiteList { get; set; }
        public Portfilterblacklist[] portFilterBlackList { get; set; }
        public string hostName { get; set; }
        public string domainName { get; set; }
        public bool ipPassThroughEnabled { get; set; }
        public bool ipPassThroughSupported { get; set; }
        public bool Ipv6Supported { get; set; }
        public bool UPNPsupported { get; set; }
        public bool UPNPenabled { get; set; }
        public Clientlist[] clientList { get; set; }
        public string end { get; set; }
    }

    public class DHCP1
    {
        public bool serverEnabled { get; set; }
        public string DNS1 { get; set; }
        public string DNS2 { get; set; }
        public string DNSmode { get; set; }
        public string USBpcIP { get; set; }
        public int leaseTime { get; set; }
        public Range1 range { get; set; }
    }

    public class Range1
    {
        public string high { get; set; }
        public string low { get; set; }
        public string end { get; set; }
    }

    public class Portfwdlist
    {
    }

    public class Portfilterwhitelist
    {
    }

    public class Portfilterblacklist
    {
    }

    public class Clientlist
    {
    }

    public class Fota
    {
        public Fwupdater fwupdater { get; set; }
    }

    public class Fwupdater
    {
        public bool available { get; set; }
        public bool chkallow { get; set; }
        public string chkstatus { get; set; }
        public int dloadProg { get; set; }
        public bool error { get; set; }
        public int lastChkDate { get; set; }
        public string state { get; set; }
        public bool isPostponable { get; set; }
        public int statusCode { get; set; }
        public int chkTimeLeft { get; set; }
        public int dloadSize { get; set; }
        public string end { get; set; }
    }

    public class Failover
    {
        public string mode { get; set; }
        public string backhaul { get; set; }
        public bool supported { get; set; }
        public int monitorPeriod { get; set; }
        public bool wanConnected { get; set; }
        public bool keepaliveEnable { get; set; }
        public int keepaliveSleep { get; set; }
        public Ipv4targets[] ipv4Targets { get; set; }
        public Ipv6targets[] ipv6Targets { get; set; }
        public string end { get; set; }
    }

    public class Ipv4targets
    {
        public string id { get; set; }
        public string _string { get; set; }
    }

    public class Ipv6targets
    {
    }

    public class Eventlog
    {
        public int level { get; set; }
        public int end { get; set; }
    }

    public class Ui
    {
        public bool serverDaysLeftHide { get; set; }
        public bool promptActivation { get; set; }
        public int end { get; set; }
    }
}