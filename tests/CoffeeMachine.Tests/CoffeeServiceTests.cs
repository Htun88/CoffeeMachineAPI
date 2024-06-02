using CoffeeMachine.Application.Interfaces;
using CoffeeMachine.Application.Services;
using Moq;
using System.Net.Http;

namespace CoffeeMachine.Tests;

public class CoffeeServiceTests
{
    private readonly CoffeeService _coffeeService;
    private readonly Mock<IDateTimeProvider> _dateTimeProviderMock;
    private readonly Mock<IWeatherService> _weatherService;


    public CoffeeServiceTests()
    {
        _dateTimeProviderMock = new Mock<IDateTimeProvider>();
        _weatherService = new Mock<IWeatherService>();  
        _coffeeService = new CoffeeService(_dateTimeProviderMock.Object, _weatherService.Object);
    }

    [Fact]
    public async Task BrewCoffee_ShouldReturnCoffeeAsync()
    {
        _dateTimeProviderMock.Setup(dp => dp.Now).Returns(DateTime.Now);

        var coffee = await _coffeeService.BrewCoffeeAsync();
        Assert.NotNull(coffee);
        Assert.Equal("Your piping hot coffee is ready", coffee.Message);
        Assert.True(coffee.Prepared <= DateTime.Now);
    }

    [Fact]
    public void IsAprilFoolsDay_ShouldReturnTrue_OnAprilFirst()
    {
        _dateTimeProviderMock.Setup(dp => dp.Now).Returns(new DateTime(2021, 4, 1));

        var result = _coffeeService.IsAprilFoolsDay();
        //Assert.Equal(DateTime.Now.Month == 4 && DateTime.Now.Day == 1, result);
        Assert.True(result);
    }

    [Fact]
    public void IsOutOfCoffee_ShouldReturnTrue_OnFifthCall()
    {
        for (int i = 0; i < 4; i++)
        {
            Assert.False(_coffeeService.IsOutOfCoffee());
        }
        Assert.True(_coffeeService.IsOutOfCoffee());
    }
}