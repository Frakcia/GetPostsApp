using System.Net;

namespace GetPostsApp.API.Middlewares
{
  public class GeneralExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<GeneralExceptionMiddleware> _logger;
    public GeneralExceptionMiddleware(RequestDelegate next, ILogger<GeneralExceptionMiddleware> logger)
    {
      _logger = logger;
      _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, ex.Message);
        await HandleExceptionAsync(httpContext, ex);
      }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)GetStatusCode(exception);
      await context.Response.WriteAsJsonAsync(exception.Message);
    }

    private HttpStatusCode GetStatusCode(Exception exception)
    {
      HttpStatusCode code;
      switch (exception)
      {
        case KeyNotFoundException
              or FileNotFoundException:
          code = HttpStatusCode.NotFound;
          break;
        case UnauthorizedAccessException:
          code = HttpStatusCode.Unauthorized;
          break;
        case ArgumentException
              or InvalidOperationException:
          code = HttpStatusCode.BadRequest;
          break;
        default:
          code = HttpStatusCode.InternalServerError;
          break;
      }

      return code;
    }
  }
}
