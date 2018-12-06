using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Domain.Extensions
{
    public static class NumberExtensions
    {
        public static double GetRandomDouble(this Random random, double min, double max)
        {
            return min + (random.NextDouble() * (max - min));
        }
    }
}
