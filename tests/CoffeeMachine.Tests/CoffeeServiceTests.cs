using CoffeeMachine.Application.Interfaces;
using CoffeeMachine.Application.Services;
using Moq;

namespace CoffeeMachine.Tests;

public class CoffeeServiceTests
{
    private readonly CoffeeService _coffeeService;
    private readonly Mock<IDateTimeProvider> _dateTimeProviderMock;

    public CoffeeServiceTests()
    {
        _dateTimeProviderMock = new Mock<IDateTimeProvider>();
        _coffeeService = new CoffeeService(_dateTimeProviderMock.Object);
    }

    [Fact]
    public void BrewCoffee_ShouldReturnCoffee()
    {
        _dateTimeProviderMock.Setup(dp => dp.Now).Returns(DateTime.Now);

        var coffee = _coffeeService.BrewCoffee();
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