namespace Airport_API.Middlewar;
//public class LogUrlMiddleware
//{
//    private readonly RequestDelegate _next;
//    private readonly ILogger _logger;

//    public LogUrlMiddleware(RequestDelegate next, ILogger logger)
//    {
//        _next = next;
//        _logger = logger;
//    }

//    public async Task InvokeAsync(HttpContext context)
//    {
//        _logger.LogInformation("called!!!");
//        await _next(context);
//    }
//}

//public static class LogUrlExtension
//{
//    public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
//    {
//        return app.UseMiddleware< LogUrlMiddleware>();
//    }
//}
public class LogUrlMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LogUrlMiddleware> _logger;

    public LogUrlMiddleware(RequestDelegate next, ILogger<LogUrlMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"Request Url:{Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
        await this._next(context);
    }
}

public static class LogUrlExtention
{
    public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LogUrlMiddleware>();
    }
}


