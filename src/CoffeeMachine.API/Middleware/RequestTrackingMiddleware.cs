namespace CoffeeMachine.API.Middleware
{
    public class RequestTrackingMiddleware
    {
        private static int _requestCount = 0;

        public RequestTrackingMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public RequestDelegate Next { get; }

        public async Task InvokeAsync(HttpContext context)
        {
            _requestCount++;
            context.Items["RequestCount"] = _requestCount;
            await Next(context);
        }
    }
}
