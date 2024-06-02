using CoffeeMachine.API.Middleware;
using CoffeeMachine.Application.Interfaces;
using CoffeeMachine.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CoffeeMachine.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<ICoffeeService, CoffeeService>();
            services.AddHttpClient<IWeatherService, WeatherService>();

            // Add Swagger services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Coffee Machine API",
                    Description = "An API to control an imaginary internet-connected coffee machine"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coffee Machine API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseMiddleware<RequestTrackingMiddleware>();
            app.UseMiddleware<CustomDateMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
