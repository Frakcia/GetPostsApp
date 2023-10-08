using GetPostsApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GetPostsApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VkApiController : ControllerBase
  {
    private readonly ICountCharsService _countCharsService;

    public VkApiController(ICountCharsService countCharsService)
    {
      _countCharsService = countCharsService;
    }

    /// <summary>
    /// Загружает посты из "ВКонтакте"
    /// </summary>
    /// <param name="ownerId">Id пользователя или группы в "ВКонтакте"</param>
    /// <returns></returns>
    [HttpGet("[action]/{ownerId}")]
    public async Task<IActionResult> LoadPosts(long ownerId)
    {
      await _countCharsService.CountsPostsChar(ownerId);
      return Ok();
    }
  }
}
