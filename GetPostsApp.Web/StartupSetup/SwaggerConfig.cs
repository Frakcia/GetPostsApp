using Microsoft.OpenApi.Models;

namespace GetPostsApp.API.StartupSetup
{
  public static class SwaggerConfig
  {
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
      _ = services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen(opt =>
        {
          opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
          var filePath = Path.Combine(AppContext.BaseDirectory, "GetPostsApp.API.xml");
          opt.IncludeXmlComments(filePath, true);
        });

      return services;
    }
  }
}
