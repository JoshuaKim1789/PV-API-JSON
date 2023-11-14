using System;
using System.Collections.Generic;
using System.Security.Permissions;

public class PvDataInitializer
{
    // Method to initialize the PvDataJson object with random values
    public static void InitializePvDataJson(PvDataJson pvData)
    {
        pvData.siteId = Program.SiteId;
        pvData.timestamp = string.Empty;

        // Initialize PvStrings
        pvData.pvString = new List<PvString>
        {
            new PvString
            {
                stringId = 1,
                voltage = 0.0,
                current = 0.0,
                power = 0
            },
            new PvString
            {
                stringId = 2,
                voltage = 0.0,
                current = 0.0,
                power = 0
            }
        };

        // Initialize Inverters
        pvData.inverter = new List<Inverter>
        {
            new Inverter
            {
                inverterId = 1,
                voltage = new List<double> { 0.0 },
                current = new List<double> { 0.0 },
                power = 0,
                powerFactor = 0,
                frequency = 0.0,
                cumulativeOutput = 0,
                state = 0
            },
            new Inverter
            {
                inverterId = 2,
                voltage = new List<double> { 0.0, 0.0, 0.0 },
                current = new List<double> { 0.0, 0.0, 0.0 },
                power = 0,
                powerFactor = 0,
                frequency = 0.0,
                cumulativeOutput = 0,
                state = 0
            }
        };

        // Initialize Battery
        pvData.battery = new Battery
        {
            SOC = 0,
            SOH = 0,
            voltage = 0.0,
            current = 0.0,
            temperature = new Temperature
            {
                min = 0.0,
                mean = 0.0,
                max = 0.0
            },
            state = 0
        };

        // public List<double> PvTemperature { get; set; }
        pvData.pvTemperature = new List<double> { 0.0, 0.0 };

        pvData.ambientTemperature = 0.0;

        pvData.wind = new Wind
        {
            speed = 0.0,
            direction = 0
        };

        pvData.irradiance = new Irradiance
        {
            GHI = 0,
            POA = new List<int> { 0, 0 }
        };

        pvData.soilingRatio = new List<int> { 0, 0 };

        pvData.pushPullForce = new List<double> { 0.0, 0.0, 0.0 };

    }
}

