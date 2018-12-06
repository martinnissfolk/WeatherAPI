using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Domain.Entities
{
    public class WeatherItem
    {
        public WeatherItem() {}

        public WeatherItem(int id, 
            DateTime date, 
            double temperature, 
            double wind, 
            double humidity, 
            double pressure, 
            int locationId)
        {
            this.Id = id;
            this.Date = date;
            this.Temperature = temperature;
            this.Wind = wind;
            this.Humidity = humidity;
            this.Pressure = pressure;
            this.LocationId = locationId;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public double Temperature { get; set; }
        public double Wind { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        
    }
}


