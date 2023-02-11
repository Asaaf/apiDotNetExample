public class TimeMiddleware
{
    private readonly RequestDelegate _next;

    public TimeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);
        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync("El request trae la palabra time");
        }
    }
}

public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}