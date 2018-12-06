using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
