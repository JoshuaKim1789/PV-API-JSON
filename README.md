# _GA Co., Ltd. PV Monitoring System API Documentation_

<p style="text-align: right;">Last Updated: January 24, 2024</p>

### Table of Contents

- [siteId](#siteid)
- [timestamp](#timestamp)
- [pvString](#pvstring)
- [inverter](#inverter)
- [battery](#battery)
- [pvTemperature](#pvtemperature)
- [ambientTemperature](#ambienttemperature)
- [wind](#wind)
- [irradiance](#irradiance)
- [soilingRatio](#soilingratio)
- [pushPullForce](#pushpullforce)

---

### siteId

```
"siteId":"0001",
```

The variable `siteId` serves as the unique identifier for a PV (photovoltaic) plant. It is of the string data type, and its value can be any string, such as "anywhere." However, for the sake of clarity and consistency, we recommend using a numeric string in the format of `"0001"` to `"9999"` to represent site identifiers.

---

### timestamp

``` 
"timestamp":"2023-10-23T15:30:00",
```

The `timestamp` value is provided in the ISO 8601 format, which is widely recognized and standardized for date and time representation. The format `YYYY-MM-DDTHH:MM:SS` provides a clear and unambiguous way to represent date and time information. In this example, the timestamp represents October 23, 2023, at 15:30:00 (3:30 PM).

---

### pvString

<pre><code>"pvString": [
      {
         "stringId": 1,
         "voltage": 20.1,
         "current": 1.9,
         "power": 38
      },
      {
         "stringId": 2,
         "voltage": 20.3,
         "current": 2.1,
         "power": 43
      }
]
</code></pre>

The JSON object `pvString` is an array that can contain one to 30 objects. Each object within the 'pvString' array possesses the following attributes:

- **stringId**: This attribute serves as a unique identifier for a PV string and is represented as a decimal integer ranging from 1 to 30. For example, `12`. It's important to note that `stringId` values are sequential, starting from 1.

- **voltage**: The `voltage` attribute represents the voltage of the PV string in volts (V). It's a decimal number with one fraction, such as `20.3V`.

- **current**: The `current` indicates the current of the PV string in amperes (A). It's presented as a decimal number with one fraction, for instance, `2.1A`.

- **power**: The `power` attribute signifies the power of the PV string, calculated as the product of voltage and current in watts (W) and represented as a decimal integer, e.g., `43W`.

This JSON object structure allows you to store information about PV strings, including their unique identifiers, voltage (in volts), current (in amperes), and calculated power (in watts).

---

### inverter

<pre><code>"inverter":[
      {
         "inverterId":1,
         "voltage":[
            220.0
         ],
         "current":[
            3.1
         ],
         "power":660,
         "powerFactor":100,
         "frequency":59.9,
         "cumulativeOutput":200.1,
         "state":0
      },
      {
         "inverterId":2,
         "voltage":[
            220.0,
            220.1,
            220.1
         ],
         "current":[
            3.0,
            3.1,
            3.0
         ],
         "power":660,
         "powerFactor":99,
         "frequency":60.0,
         "cumulativeOutput":220.3,
         "state":0
      }
   ],
</code></pre>

The JSON object `inverter` is an array that can contain one to 30 objects. Each object within the `inverter` array possesses the following attributes:

- **inverterId**: This attribute serves as a unique identifier for a PV inverter and is represented as a decimal integer ranging from 1 to 30, e.g., `12`. It's important to note that `inverterId` values are sequential, starting from 1.

- **voltage**: The `voltage` attribute represents the voltage(s) of the PV inverter in volts (V). In the array, it can comprise one or three elements for single-phase or three-phase systems, respectively. Each element is a decimal number with one fraction, such as `220.3V`.

- **current**: The `current` attribute indicates the current of the PV inverter, presented as an array with one or three elements for single-phase or three-phase systems, respectively, measured in amperes (A). Each element is a decimal number with one fraction, for instance, `2.1A`.

- **power**: The `power` attribute signifies the power of the PV inverter, calculated as the product of voltage and current, and is measured in watts (W). It is represented as a decimal integer, e.g., `600W`.

- **powerFactor**: The `powerFactor` attribute represents the power factor of the PV inverter in percent (%), and it is represented as a decimal integer, e.g., `99%`.

- **frequency**: The `frequency` attribute denotes the frequency of the PV inverter in hertz (Hz) and is a decimal number with one fraction, e.g., `59.9Hz`.

- **cumulativeOutput**: The `cumulativeOutput` attribute describes the accumulated power over time of the PV inverter in kilowatt-hours (kWh). It is represented as a decimal number with one fraction, e.g., `220.1kWh`.

- **state**: The `state` attribute deciphers the state of the PV inverter using a 16-bit code.

| Bit 15 | Bit 14 | Bit 13 | Bit 12 | Bit 11 | Bit 10 | Bit 09 | Bit 08 |
|:------:|:------:|:------:|:------:|:------:|:------:|:------:|:------:|
| Reserved | Reserved | Bit 05 | Bit 04 | Bit 03 | Bit 02 | Bit 01 | Bit 00 |

| Bit 07            | Bit 06           | Bit 05           | Bit 04  | Bit 03         | Bit 02          | Bit 01         | Bit 00       |
|:------:           |:------:          |:------:          |:------: |:------:        |:------:         |:------:        |:------:      |
| Grid Undervoltage | Grid Overvoltage | Over temperature | IGBT    | PV Overcurrent | PV Undervoltage | PV Overvoltage | Inverter Run |
| 0=Normal          | 0=Normal         | 0=Normal         | 0=Normal| 0=Normal       | 0=Normal        | 0=Normal       | 0=Run        |
| 1=UV              | 1=OV             | 1=OT             | 1=Fault | 1=OC           | 1=UV            | 1=OV           | 1=Stop       |

This JSON object structure allows you to store detailed information about PV inverters, including their unique identifiers, voltage (in volts), current (in amperes), calculated power (in watts), power factor (in %), frequency (in Hz), cumulative output (in kWh), and state.

---

### battery

<pre><code>"battery":{
      "SOC":90,
      "SOH":100,
      "voltage":48.3,
      "current":5.4,
      "temperature":{
         "min":25.4,
         "mean":33.6,
         "max":55.3
      },
      "state":0
   },
</code></pre>

The `battery` JSON object provides information about battery storage:

- **SOC (State of Charge)**: `SOC` represents the battery's state of charge in percent (%), and it is presented as a decimal integer, e.g., `90%`.

- **SOH (State of Health)**: `SOH` represents the battery's state of health in percent (%), and it is represented as a decimal integer, e.g., `100%`.

- **voltage**: The `voltage` attribute indicates the voltage of the battery in volts (V). It's a decimal number with one fraction, such as `48.3V`.

- **current**: The `current` attribute signifies the current of the battery in amperes (A). It's presented as a decimal number with one fraction, for instance, `5.4A`.
    -  Positive Battery Current **(+)**: Discharge, indicating energy is being supplied from the battery to power loads.
    - Negative Battery Current **(-)**: Charge, indicating energy is being supplied to the battery for charging.

- **temperature**: The `temperature` attribute provides details on the battery's temperature. It includes sub-objects for `min`, `mean`, and `max`, which represent the minimum, mean, and maximum temperatures recorded by temperature sensors. Temperatures are measured in degrees Celsius (°C) as decimal numbers with one fraction, e.g., `33.6°C`. If a single temperature sensor is in use, the `mean` value should be considered, with others as null.

- **state**: The `state` attribute deciphers the state of the battery using a 16-bit code.

This JSON object structure allows you to gather comprehensive information about battery storage, including its state of charge, state of health, voltage, current, temperature data, and operational state.

---

### pvTemperature

<pre><code>"pvTemperature":[
      50.5,
      51.2
   ],
</code></pre>

The `pvTemperature` JSON object is an array that can contain one to 30 elements. Each element in the array represents the temperature of a PV (photovoltaic) module in degrees Celsius (°C) and is expressed as a decimal number with one fraction. For example, `50.5°C`.

If a single PV temperature sensor is in use, the array contains one element representing the current temperature reading.

---

### ambientTemperature

<pre><code>"ambientTemperature":25.3,
</code></pre>

The `ambientTemperature` JSON object represents the ambient temperature in degrees Celsius (°C) and is expressed as a decimal number with one fraction, e.g., `25.3°C`.

---

### wind

<pre><code>"wind":{
      "speed":4.5,
      "direction":180
   },
</code></pre>

The `wind` JSON object comprises two key attributes:

- **speed**: The `speed` attribute quantifies wind speed in meters per second (m/s) with one decimal fraction, represented as `4.5 m/s`.

- **direction**: The `direction` attribute specifies the wind direction, expressed as a decimal integer in degrees relative to true north (°). For instance, `0°` corresponds to the north, `90°` to the east, `180°` to the south, and `270°` to the west.

---

### irradiance

<pre><code>"irradiance":{
      "GHI":455,
      "POA":[
         830,
         741
      ]
},
</code></pre>

The `irradiance` JSON object encompasses two key attributes:

- **GHI (Global Horizontal Irradiance)**: This attribute represents the Global Horizontal Irradiance and is denoted by `GHI`. It's expressed as a decimal integer in watts per square meter (W/m²), for example, `455W/m²`.

- **POA (Plane of Array)**: The `POA` attribute stands for 'Plane of Array' irradiance and is represented as an array. It can contain one or up to 10 elements, depending on the PV plant size. Each element in the `POA` array is a decimal integer in watts per square meter (W/m²), similar to `GHI`. For instance, `830W/m²`.

The 'irradiance' object allows you to gather information about both Global Horizontal Irradiance (`GHI`) and Plane of Array (`POA`) irradiance, crucial for photovoltaic systems' performance assessment.

---

### soilingRatio 

<pre><code>"soilingRatio":[
      12,
      15
   ],
</code></pre>

The `soilingRatio` JSON object provides insights into the soiling ratio of PV panels. It can encompass zero to ten values, depending on the number of installed soiling sensors and the size of the PV plant.

Each element within the `soilingRatio` array is represented as a decimal integer in percentage (%), such as `12%`. A reading of `0%` indicates the absence of soiling or perfect cleanliness, while `100%` represents complete soiling or a significant reduction in energy output.

This object enables monitoring and understanding the soiling conditions affecting the performance of PV panels within the plant.

---

### pushPullForce

<pre><code>"pushPullForce":[
      0.1,
      -0.2,
      0.3
   ]
</code></pre>

The `pushPullForce` JSON object is used to measure forces at PV structure joint points, providing insights into the structure's health. Each value in the array is represented as a decimal number with one fraction in kilograms (kg), for example, `0.3kg`. 

In this context:
- A positive value indicates a push force.
- A negative value indicates a pull force.

The `pushPullForce` array can contain up to 10 elements, depending on the number of sensors installed. If no force sensor is present, the array remains null. If any element in the array exceeds a certain threshold, it indicates a structural issue that requires attention.

This object is valuable for monitoring and identifying problems in the PV structure based on force measurements.

--