# PV-API-JSON 
## _PV monitoring system API_, _GA Co., Ltd._

### Table of Contents

- [siteId](#siteId)
- [timestamp](#timestamp)
- [string](#string)
- [inverter](#inverter)
- [battery](#battery)
- [PVtemperature](#PVtemperature)
- [ambientTemperature](#ambientTemperature)
- [wind](#wind)
- [irradiance](#irradiance)
- [soilingRatio](#soilingRatio)
- [rainFall](#rainFall)
- [pushPullForce](#pushPullForce)

### siteId
```
"siteId":"0001",
```

The variable `siteId` serves as the unique identifier for a PV (photovoltaic) plant. It is of the string data type, and its value can be any string, such as "anywhere." However, for the sake of clarity and consistency, we recommend using a numeric string in the format of '0001' to '9999' to represent site identifiers.

---

### timestamp
``` 
"timestamp":"2023-10-23T15:30:00",
```

The `timestamp` value is provided in the ISO 8601 format, which is widely recognized and standardized for date and time representation. The format "YYYY-MM-DDTHH:MM:SS" provides a clear and unambiguous way to represent date and time information. In this example, the timestamp represents October 23, 2023, at 15:30:00 (3:30 PM).

---

### string
<pre><code>
"string": [
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

The JSON object `string` is an array that can contain one to 30 objects. Each object within the 'string' array possesses the following attributes:

- **stringId**: This attribute serves as a unique identifier for a PV string and is represented as a decimal integer ranging from 1 to 30. For example, `12`. It's important to note that `stringId` values are sequential, starting from 1.

- **voltage**: The `voltage` attribute represents the voltage of the PV string in volts (V). It's a decimal number with one fraction, such as `20.3V`.

- **current**: The `current` indicates the current of the PV string in amperes (A). It's presented as a decimal number with one fraction, for instance, `2.1A`.

- **power**: The `power` attribute signifies the power of the PV string, calculated as the product of voltage and current in watts (W) and represented as a decimal integer, e.g., `43W`.

This JSON object structure allows you to store information about PV strings, including their unique identifiers, voltage (in volts), current (in amperes), and calculated power (in watts).

---

### inverter
<pre><code>
   "inverter":[
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
         "cumOutput":2000,
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
         "cumOutput":2200,
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

- **cumOutput**: The `cumOutput` attribute describes the accumulated power over time of the PV inverter in kilowatt-hours (kWh). It is represented as a decimal integer, e.g., `2200kWh`.

- **state**: The `state` attribute deciphers the state of the PV inverter using a 16-bit code.

This JSON object structure allows you to store detailed information about PV inverters, including their unique identifiers, voltage (in volts), current (in amperes), calculated power (in watts), power factor (in %), frequency (in Hz), cumulative output (in kWh), and state.

---

### battery
<pre><code>
   "battery":{
      "SOC":90,
      "SOH":100,
      "voltage":24.1,
      "current":5.4,
      "temperature":{
         "min":25.4,
         "mean":33.6,
         "max":55.3
      },
      "state":0
   },
</code></pre>

The 'battery' JSON object provides information about battery storage:

- **SOC (State of Charge)**: SOC represents the battery's state of charge in percent (%), and it is presented as a decimal integer, e.g., `90%`.

- **SOH (State of Health)**: SOH represents the battery's state of health in percent (%), and it is represented as a decimal integer, e.g., `100%`.

- **Voltage**: The 'voltage' attribute indicates the voltage of the battery in volts (V). It's a decimal number with one fraction, such as `48.3V`.

- **Current**: The 'current' attribute signifies the current of the battery in amperes (A). It's presented as a decimal number with one fraction, for instance, `5.4A`.

- **Temperature**: The 'temperature' attribute provides details on the battery's temperature. It includes sub-objects for 'min,' 'mean,' and 'max,' which represent the minimum, mean, and maximum temperatures recorded by temperature sensors. Temperatures are measured in degrees Celsius (°C) as decimal numbers with one fraction, e.g., `33.6°C`. If a single temperature sensor is in use, the 'mean' value should be considered, with others as null.

- **State**: The 'state' attribute deciphers the state of the battery using a 16-bit code.

This JSON object structure allows you to gather comprehensive information about battery storage, including its state of charge, state of health, voltage, current, temperature data, and operational state.

---

### PVtemperature
<pre><code>
   "PVtemperature":[
      50.5,
      51.2
   ],
</code></pre>

The 'PVtemperature' JSON object is an array that can contain one to 30 elements. Each element in the array represents the temperature of a PV (photovoltaic) module in degrees Celsius (°C) and is expressed as a decimal number with one fraction. For example, `50.5°C`.

If a single PV temperature sensor is in use, the array contains one element representing the current temperature reading.

---

### ambientTemperature
<pre><code>
   "ambientTemperature":25.3,
</code></pre>

The 'ambientTemperature' JSON object represents the ambient temperature in degrees Celsius (°C) and is expressed as a decimal number with one fraction, e.g., `25.3°C`.

---

### wind
<pre><code>
   "wind":{
      "speed":4.5,
      "direction":180
   },
</code></pre>

---

### irradiance
<pre><code>
   "irradiance":{
      "GHI":10.3,
      "POA":[
         8.3,
         7.4
      ]
   },
</code></pre>

---

### soilingRatio 
<pre><code>
   "soilingRatio":[
      0.12,
      0.15
   ],
</code></pre>

---

### rainFall
<pre><code>
   "rainFall":11.5,
</code></pre>

---

### pushPullForce
<pre><code>
   "pushPullForce":[
      0.1,
      -0.2,
      0.3
   ]
</code></pre>

---