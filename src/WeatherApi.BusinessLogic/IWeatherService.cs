using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Domain.Entities;

namespace WeatherApi.BusinessLogic
{
    public interface IWeatherService
    {
        bool HasItems();
        void AddItems();
        Task<WeatherItem> GetWeatherByCityAsync(string city);
    }
}
