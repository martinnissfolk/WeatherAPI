using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Data;
using WeatherApi.Domain.Entities;
using WeatherApi.Domain.Extensions;

namespace WeatherApi.BusinessLogic
{
    public class WeatherService : IWeatherService
    {
        private WeatherContext _context;

        public WeatherService(WeatherContext context)
        {
            _context = context;
        }

        public bool HasItems()
        {
            return _context.WeatherItems.Any();
        }

        public void AddItems()
        {
            _context.Locations.AddRange(
                new Location(1, "Västerås",  "721 30"),
                new Location(2, "Västerås",  "722 28"),
                new Location(3, "Malmö",     "211 11"),
                new Location(4, "Stockholm", "112 44")
                );
            _context.SaveChanges();

            var random = new Random();

            _context.WeatherItems.AddRange(
                new WeatherItem(1, DateTime.Now, 
                    random.GetRandomDouble(-20, 40), 
                    random.GetRandomDouble(0, 103),
                    random.GetRandomDouble(0, 100),
                    random.GetRandomDouble(-20, 40), 
                    1),

                new WeatherItem(2, 
                    DateTime.Now, 
                    random.GetRandomDouble(-20, 40),
                    random.GetRandomDouble(0, 103),
                    random.GetRandomDouble(0, 100),
                    random.GetRandomDouble(-20, 40),
                    2),
                
                new WeatherItem(3, DateTime.Now, 
                    random.GetRandomDouble(-20, 40),
                    random.GetRandomDouble(0, 103),
                    random.GetRandomDouble(0, 100),
                    random.GetRandomDouble(-20, 40), 
                    3),
                new WeatherItem(4, DateTime.Now, 
                    random.GetRandomDouble(-20, 40),
                    random.GetRandomDouble(0, 103),
                    random.GetRandomDouble(0, 100),
                    random.GetRandomDouble(-20, 40), 
                    4),
                new WeatherItem(5, DateTime.Now.AddDays(-2), 
                    random.GetRandomDouble(-20, 40),
                    random.GetRandomDouble(0, 103),
                    random.GetRandomDouble(0, 100),
                    random.GetRandomDouble(-20, 40), 4)
                );
            _context.SaveChanges();
        }

        public async Task<WeatherItem> GetWeatherByCityAsync(string searchString)
        {
            return await _context.WeatherItems
                .Where(x => x.Location.City.ToLower() == searchString.Trim().ToLower() || x.Location.ZipCode.Trim() == searchString.Trim())
                .Include(x => x.Location)
                .FirstOrDefaultAsync();
        }
    }
}
