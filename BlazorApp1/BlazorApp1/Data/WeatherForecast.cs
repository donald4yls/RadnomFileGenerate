using System.Text.Json.Serialization;

namespace BlazorApp1.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }


    [JsonSerializable(typeof(WeatherForecast))]
    [JsonSerializable(typeof(List<WeatherForecast>))]
    [JsonSerializable(typeof(IEnumerable<WeatherForecast>))]
    [JsonSerializable(typeof(Dictionary<string, WeatherForecast>))]
    internal partial class WeatherForecastContext : JsonSerializerContext
    {
    }
}