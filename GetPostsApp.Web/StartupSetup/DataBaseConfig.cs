using GetPostsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GetPostsApp.API.StartupSetup
{
  public static class DataBaseConfig
  {
    public static IServiceCollection AddDataBaseConfig(this IServiceCollection services, ConfigurationManager configuration)
    {
      _ = services.AddDbContext<ApplicationDbContext>(options =>
          options.UseNpgsql(configuration.GetConnectionString("postgresConnection")), ServiceLifetime.Scoped);

      return services;
    }
  }
}
