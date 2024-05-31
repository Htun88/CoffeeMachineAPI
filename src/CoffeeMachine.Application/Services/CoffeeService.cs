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
        private static int _callCount = 0;
        private const int OutOfCoffeeThreshold = 5;

        public CoffeeService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public Coffee BrewCoffee()
        {
            return new Coffee
            {
                Message = "Your piping hot coffee is ready",
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
