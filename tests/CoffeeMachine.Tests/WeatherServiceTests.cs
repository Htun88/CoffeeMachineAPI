using CoffeeMachine.Application.Interfaces;
using CoffeeMachine.Application.Services;
using Moq.Protected;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Tests
{
    public class WeatherServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly IWeatherService _weatherService;

        public WeatherServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _weatherService = new WeatherService(_httpClient);
        }

        [Fact]
        public async Task GetCurrentTemperatureAsync_ShouldReturnTemperature()
        {
            // Arrange
            var responseContent = @"{
                'main': {
                    'temp': 31.5
                }
            }";
            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent)
                });

            // Act
            var temperature = await _weatherService.GetCurrentTemperatureAsync();

            // Assert
            Assert.Equal(31.5, temperature);
        }

        [Fact]
        public async Task GetCurrentTemperatureAsync_ShouldHandleErrorResponse()
        {
            // Arrange
            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                });

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _weatherService.GetCurrentTemperatureAsync());
        }
    }
}
