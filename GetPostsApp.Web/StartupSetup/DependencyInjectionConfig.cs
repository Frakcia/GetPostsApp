using GetPostsApp.Application.Services;
using GetPostsApp.Domain.Services;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet;
using GetPostsApp.Domain.Repositories;
using GetPostsApp.Infrastructure.Repositories;

namespace GetPostsApp.API.StartupSetup
{
  public static class DependencyInjectionConfig
  {
    public static IServiceCollection RegisterServices(this IServiceCollection services, ConfigurationManager configuration)
    {
      services.AddScoped<IVkApiService, VkApiService>();
      services.AddScoped<ICountCharsService, CountCharsService>();
      services.AddScoped<IRepository, Repository>();

      var vkApiAccessToken = configuration["VkApiAccessToken"];

      var api = new VkApi();
      api.Authorize(new ApiAuthParams
      {
        AccessToken = vkApiAccessToken,
        Settings = Settings.All
      });

      services.AddSingleton(api);

      return services;
    }
  }
}
