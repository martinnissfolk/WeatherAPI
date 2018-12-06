using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.BusinessLogic;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
            if (!_weatherService.HasItems())
            {
                _weatherService.AddItems();
            }
        }
        
        [HttpGet("{searchString}")]
        public async Task<ActionResult<WeatherItem>> Get(string searchString)
        {
            var weatherItem = await _weatherService.GetWeatherByCityAsync(searchString);

            if (weatherItem == null)
            {
                return NotFound();
            }

            var result = new WeatherItem
            {
                Id = weatherItem.Id,
                Date = weatherItem.Date,
                Temperature = weatherItem.Temperature,
                Wind = weatherItem.Wind,
                Humidity = weatherItem.Humidity,
                Location = new Location()
                {
                    Id = weatherItem.LocationId,
                    City = weatherItem.Location.City,
                    ZipCode = weatherItem.Location.ZipCode
                }
            };

            return result;
        }
        
    }
}
