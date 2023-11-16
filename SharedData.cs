using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class SharedData
{
    // Define server and OpenWeatherMap details
    public const string serverUrl = "http://zoomok.hscommunity2017.gethompy.com/api/push.php";
    public const string openWeatherMapApiKey = "fcfc44e2f20171a8c04b1672b8436860";
    public const string openWeatherMapCity = "Wonju-si,KR";
    public const string openWeatherMapUnits = "metric";

    public static string jsonStringRaw { get; set; }
    public static PvDataJson pvSiteUse { get; set; }
    public static double ambientTemperature { get; set; }
    public static double windSpeed { get; set; }
    public static int windDirection { get; set; }
}

