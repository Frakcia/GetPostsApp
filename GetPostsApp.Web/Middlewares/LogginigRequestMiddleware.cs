namespace GetPostsApp.API.Middlewares
{
  public class LogginigRequestMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<GeneralExceptionMiddleware> _logger;
    public LogginigRequestMiddleware(RequestDelegate next, ILogger<GeneralExceptionMiddleware> logger)
    {
      _logger = logger;
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      var requestUlt = $"{context.TraceIdentifier}: {context.Request.Path} {context.Request.Method}";

      _logger.LogInformation($"{requestUlt} {DateTime.UtcNow}");

      await _next(context);

      _logger.LogInformation($"{requestUlt} {DateTime.UtcNow}");
    }
  }
}
