using GetPostsApp.Domain.DTO;
using GetPostsApp.Domain.Services;
using Mapster;
using VkNet;
using VkNet.Model;

namespace GetPostsApp.Application.Services
{
  public class VkApiService : IVkApiService
  {
    private readonly VkApi _vkApi;

    public VkApiService(VkApi vkApi)
    {
      _vkApi = vkApi;
    }

    /// <summary>
    /// Get users or group wall posts
    /// </summary>
    /// <param name="ownerId">id пользователя или группы</param>
    /// <param name="count">колличество постов</param>
    /// <returns></returns>
    public async Task<IEnumerable<VkPostDTO>> GetWallPostsAsync(long ownerId, ulong count)
    {
      var posts = await _vkApi.Wall.GetAsync(new WallGetParams
      {
        OwnerId = ownerId, // id пользователя или группы
        Count = count // количество постов
      });

      return posts.WallPosts.Select(e => e.Adapt<VkPostDTO>()).ToList();
    }
  }
}
