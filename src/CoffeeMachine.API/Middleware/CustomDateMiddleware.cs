using CoffeeMachine.Application.Interfaces;

namespace CoffeeMachine.API.Middleware
{
    public class CustomDateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CustomDateMiddleware(RequestDelegate next, IDateTimeProvider dateTimeProvider)
        {
            _next = next;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("X-Custom-Date", out var customDateValue) &&
                DateTime.TryParse(customDateValue, out var customDate))
            {
                _dateTimeProvider.SetCustomDate(customDate);
            }
            else
            {
                _dateTimeProvider.ResetDate();
            }

            await _next(context);
        }
    }
}
