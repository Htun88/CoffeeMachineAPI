# Coffee Machine API

This repository contains an HTTP API for controlling an imaginary internet-connected coffee machine.

## Description

The Coffee Machine API provides endpoints to brew coffee, check the availability of coffee, and more. It follows the specifications outlined in the requirements.

## Getting Started

To get started with the Coffee Machine API, follow these steps:

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)
- [OpenWeatherMap API Key](https://openweathermap.org/api)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/coffee-machine-api.git

2. Navigate to the project directory:
    cd coffee-machine-api

3. Set up the OpenWeatherMap API Key:

Open src/CoffeeMachine.Application/Services/WeatherService.cs.
Replace YourAPIKey with your actual API key.
Replace YourCity with the desired city to get the weather information.

### Usage
Build the project:

dotnet build

Run the project:
dotnet run --project CoffeeMachine.API

The API will be accessible at http://localhost:0000.

### Endpoints
GET /api/coffee/brew-coffee: Brew coffee. If the temperature is above 30°C, returns "Your refreshing iced coffee is ready". Otherwise, returns "Your piping hot coffee is ready".


## Custom Date
The API supports a custom date feature, allowing you to simulate different dates for testing purposes.

To use the custom date feature:

Include a X-Custom-Date header in your request with the desired date in ISO-8601 format (e.g., 2023-04-01T00:00:00Z for April 1st, 2023).
Send the request to the desired endpoint.

### Swagger Documentation
The API documentation is available using Swagger UI:

### Run the project.
Navigate to http://localhost:0000/swagger.


   
