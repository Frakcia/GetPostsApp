using GetPostsApp.Domain.DTO;

namespace GetPostsApp.Domain.Services
{
  public interface IVkApiService
  {
    Task<IEnumerable<VkPostDTO>> GetWallPostsAsync(long ownerId, ulong count);
  }
}
