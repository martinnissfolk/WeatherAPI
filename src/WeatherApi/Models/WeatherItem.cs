using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Models
{
    public class WeatherItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public double Temperature { get; set; }
        public double Wind { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
    }
}


