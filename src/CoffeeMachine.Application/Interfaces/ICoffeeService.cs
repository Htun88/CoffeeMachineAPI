using CoffeeMachine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Application.Interfaces
{
    public interface ICoffeeService
    {
        Task<Coffee> BrewCoffeeAsync();
        bool IsAprilFoolsDay();
        bool IsOutOfCoffee();
    }
}
