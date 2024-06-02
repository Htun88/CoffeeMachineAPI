using CoffeeMachine.Application.Interfaces;
using CoffeeMachine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Application.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IWeatherService _weatherService;
        private static int _callCount = 0;
        private const int OutOfCoffeeThreshold = 5;

        public CoffeeService(IDateTimeProvider dateTimeProvider, IWeatherService weatherService)
        {
            _dateTimeProvider = dateTimeProvider;
            _weatherService = weatherService;
        }

        public async Task<Coffee> BrewCoffeeAsync()
        {
            var temperature = await _weatherService.GetCurrentTemperatureAsync();
            var message = temperature > 30 ? "Your refreshing iced coffee is ready" : "Your piping hot coffee is ready";
            return new Coffee
            {
                Message = message,
                Prepared = _dateTimeProvider.Now
            };
    
        }

        public bool IsAprilFoolsDay()
        {
            var today = _dateTimeProvider.Now;
            return today.Month == 4 && today.Day == 1;
        }

        public bool IsOutOfCoffee()
        {
            _callCount++;
            return _callCount % OutOfCoffeeThreshold == 0;
        }
    }
}
