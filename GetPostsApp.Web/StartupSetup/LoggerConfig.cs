using Serilog;

namespace GetPostsApp.API.StartupSetup
{
  public static class LoggerConfig
  {
    public static ILoggingBuilder AddLogger(this ILoggingBuilder loggingBuilder, ConfigurationManager configuration)
    {
      var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

      loggingBuilder.ClearProviders();
      loggingBuilder.AddSerilog(logger);

      return loggingBuilder;
    }
  }
}
