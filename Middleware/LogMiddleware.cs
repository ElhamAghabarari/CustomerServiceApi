namespace CustomerServiceApi.Middleware
{
    public class LogMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //Console.WriteLine($"method is: {context.Request.Method}");

            if (context.Request.Path.StartsWithSegments("/hello"))
            {
                await context.Response.WriteAsync("Hello, World!");
            }
            else
            {
                await next(context);
            }

            //Console.WriteLine($"response status is: {context.Response.StatusCode}");

        }
    }
}
