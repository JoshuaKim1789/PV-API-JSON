using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

class Program
{
    static async Task Main()
    {
        SharedData.pvSiteUse = new PvDataJson();
        // Initialize the object 
        PvDataInitializer.InitializePvDataJson(SharedData.pvSiteUse);
        PvDataUpdate.UpdatePvDataJson(SharedData.pvSiteUse);

        // Convert the object to a JSON string
        SharedData.jsonStringRaw = Newtonsoft.Json.JsonConvert.SerializeObject(SharedData.pvSiteUse);
        string jsonStringPretty = JsonConvert.SerializeObject(SharedData.pvSiteUse, Formatting.Indented);

        // Print the JSON string
        Console.WriteLine(jsonStringPretty);

        // Create a CancellationTokenSource for handling Ctrl+C termination
        var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (sender, e) => {
            e.Cancel = true; // prevent the process from terminating
            cts.Cancel();    // cancel the tasks
        };

        // Create tasks
        var taskA = Task.Run(() => TaskPostToServer(SharedData.serverUrl, SiteData.intervalA, cts.Token), cts.Token);
        var taskB = Task.Run(() => TaskGetWeather(SharedData.openWeatherMapApiKey, SharedData.openWeatherMapCity, SharedData.openWeatherMapUnits, SiteData.intervalB, cts.Token), cts.Token);
        var taskC = Task.Run(() => TaskUpdateJson(SiteData.intervalC, cts.Token), cts.Token);

        // Wait for Ctrl+C to terminate the program
        await Task.Delay(Timeout.Infinite, cts.Token);
    }

    static async Task TaskPostToServer(string serverUrl, int interval, CancellationToken cancellationToken)
    {
        // Use StreamWriter for writing to the log file
        using (StreamWriter errorLogWriter = new StreamWriter("error_trace.log", true))
        using (var httpClient = new HttpClient())
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                PvDataUpdate.UpdatePvDataJson(SharedData.pvSiteUse);
                SharedData.jsonStringRaw = Newtonsoft.Json.JsonConvert.SerializeObject(SharedData.pvSiteUse);
                string jsonString = SharedData.jsonStringRaw;

                try
                {
                    // Monitor Request body
                    Console.WriteLine($"TaskA - Request Body: {jsonString}");
                    // Send HTTP POST request
                    var response = await httpClient.PostAsync(serverUrl, new StringContent(jsonString), cancellationToken);

                    // Display response code and body
                    Console.WriteLine($"TaskA - HTTP Status Code: {response.StatusCode} ({(int)response.StatusCode})");
                    Console.WriteLine($"TaskA - Response Body: {await response.Content.ReadAsStringAsync()}");

                    // Check if the response status code is not 200
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        // Log error information to the file
                        string errorLogMessage = $"{SharedData.pvSiteUse.timestamp} TaskA - HTTP Status Code: {response.StatusCode} ({(int)response.StatusCode})" +
                                                 $"Error Response Body: {await response.Content.ReadAsStringAsync()}\n";
                        errorLogWriter.WriteLine(errorLogMessage);
                        errorLogWriter.Flush(); // Ensure the content is written immediately
                    }

                    // Wait for the specified interval
                    await Task.Delay(TimeSpan.FromSeconds(interval), cancellationToken);
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., network issues) and log to the file
                    string errorLogMessage = $"{SharedData.pvSiteUse.timestamp} TaskA - Exception: {ex.Message}\n";
                    errorLogWriter.WriteLine(errorLogMessage);
                    errorLogWriter.Flush(); // Ensure the content is written immediately

                    // Wait for the specified interval before retrying
                    await Task.Delay(TimeSpan.FromSeconds(interval), cancellationToken);
                }
            }
        }
    }

    static async Task TaskGetWeather(string apiKey, string city, string units, int interval, CancellationToken cancellationToken)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // Prepare OpenWeatherMap API URL
                string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}";

                // Send HTTP GET request
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize and extract required information (replace this with actual logic)
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);
                    double temperature = weatherData.main.temp;
                    temperature = Math.Round(temperature, 1);
                    SharedData.ambientTemperature = temperature;
                    double windspeed = weatherData.wind.speed;
                    windspeed = Math.Round(windspeed, 1);
                    SharedData.windSpeed = windspeed;
                    int winddeg = weatherData.wind.deg;
                    SharedData.windDirection = winddeg;
                    // Display extracted information
                    Console.WriteLine($"TaskB - Temperature: {temperature}, Wind Speed: {windspeed}, Wind Deg: {winddeg}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve weather data. Status code: " + response.StatusCode);
                }
                // Wait for the specified interval
                await Task.Delay(TimeSpan.FromSeconds(interval), cancellationToken);
            }
        }
    }

    static async Task TaskUpdateJson(int interval, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            // Run something reserved (replace this with your reserved task logic)
            Console.WriteLine("TaskC - Running something reserved...");

            // Wait for the specified interval
            await Task.Delay(interval, cancellationToken);
        }
    }

}
