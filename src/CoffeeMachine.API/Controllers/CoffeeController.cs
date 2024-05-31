using CoffeeMachine.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeeController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet("brew-coffee")]
        public IActionResult BrewCoffee()
        {
            if (_coffeeService.IsAprilFoolsDay())
            {
                return StatusCode(418, new { message = "418 I'm a teapot" });
            }

            if (_coffeeService.IsOutOfCoffee())
            {
                return StatusCode(503);
            }

            var coffee = _coffeeService.BrewCoffee();
            return Ok(new
            {
                message = coffee.Message,
                prepared = coffee.Prepared.ToString("o")
            });
        }
    }
}
