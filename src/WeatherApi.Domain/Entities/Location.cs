using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Domain.Entities
{
    public class Location
    {
        public Location() { }

        public Location(int id, string city, string zipCode)
        {
            this.Id = id;
            this.City = city;
            this.ZipCode = zipCode;
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public ICollection<WeatherItem> WeatherItems { get; set; }
    }
}
