using CoffeeMachine.Application.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> GetCurrentTemperatureAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?q=Sydney&units=metric&appid=23e55b26510ca2346708017e41263513");
            var json = JObject.Parse(response);
            return json["main"]["temp"].Value<double>();
        }
    }
}
