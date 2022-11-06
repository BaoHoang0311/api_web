using System;

namespace API_hienchanel
{
    public class WeatherForecast
    {
        // T1
        // T2
        // T3 + 1 dòng
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
