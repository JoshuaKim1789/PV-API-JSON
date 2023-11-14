using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PvDataJson
{
    public string siteId { get; set; }
    public string timestamp { get; set; }
    public List<PvString> pvString { get; set; }
    public List<Inverter> inverter { get; set; }
    public Battery battery { get; set; }
    public List<double> pvTemperature { get; set; }
    public double ambientTemperature { get; set; }
    public Wind wind { get; set; }
    public Irradiance irradiance { get; set; }
    public List<int> soilingRatio { get; set; }
    public List<double> pushPullForce { get; set; }
}

public class PvString
{
    public int stringId { get; set; }
    public double voltage { get; set; }
    public double current { get; set; }
    public int power { get; set; }
}

public class Inverter
{
    public int inverterId { get; set; }
    public List<double> voltage { get; set; }
    public List<double> current { get; set; }
    public int power { get; set; }
    public int powerFactor { get; set; }
    public double frequency { get; set; }
    public ulong cumulativeOutput { get; set; }
    public ushort state { get; set; }
}

public class Battery
{
    public int SOC { get; set; }
    public int SOH { get; set; }
    public double voltage { get; set; }
    public double current { get; set; }
    public Temperature temperature { get; set; }
    public ushort state { get; set; }
}

public class Temperature
{
    public double min { get; set; }
    public double mean { get; set; }
    public double max { get; set; }
}

public class Wind
{
    public double speed { get; set; }
    public int direction { get; set; }
}

public class Irradiance
{
    public int GHI { get; set; }
    public List<int> POA { get; set; }
}
