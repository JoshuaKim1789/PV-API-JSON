# PV-API-JSON 
## _PV monitoring system API_, _GA Co., Ltd._

```
"siteId":"0001",
```

The variable `siteId` serves as the unique identifier for a PV (photovoltaic) plant. It is of the string data type, and its value can be any string, such as "anywhere." However, for the sake of clarity and consistency, we recommend using a numeric string in the format of '0001' to '9999' to represent site identifiers.

---

``` 
"timestamp":"2023-10-23T15:30:00",
```

The `timestamp` value is provided in the ISO 8601 format, which is widely recognized and standardized for date and time representation. The format "YYYY-MM-DDTHH:MM:SS" provides a clear and unambiguous way to represent date and time information. In this example, the timestamp represents October 23, 2023, at 15:30:00 (3:30 PM).

---

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

The JSON object 'string' is an array that can contain one to 30 objects. Each object within the 'string' array possesses the following attributes:

- **stringId**: This attribute serves as a unique identifier for a PV string and is represented as a decimal integer ranging from 1 to 30. For example, `12`. It's important to note that 'stringId' values are sequential, starting from 1.

- **voltage**: The 'voltage' attribute represents the voltage of the PV string. It's a decimal number with one fraction, such as `20.3`.

- **current**: 'current' indicates the current of the PV string, presented as a decimal number with one fraction, for instance, `2.1`.

- **power**: The 'power' attribute signifies the power of the PV string, calculated as the product of voltage and current. It's represented as a decimal integer, e.g., `43`.

This JSON object structure allows you to store information about PV strings, including their unique identifiers, voltage, current, and calculated power.