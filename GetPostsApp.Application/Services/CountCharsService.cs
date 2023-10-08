using GetPostsApp.Domain.Entities;
using GetPostsApp.Domain.Repositories;
using GetPostsApp.Domain.Services;

namespace GetPostsApp.Application.Services
{
  public class CountCharsService : ICountCharsService
  {
    private readonly IVkApiService _vkApiService;
    private readonly IRepository _repository;
    private const ulong postCount = 5;
    public CountCharsService(IVkApiService vkApiService, IRepository repository)
    {
      _vkApiService = vkApiService;
      _repository = repository;
    }

    public async Task CountsPostsChar(long ownerId)
    {
      var posts = await _vkApiService.GetWallPostsAsync(ownerId, postCount);

      if(!posts.Any())
      {
        return;
      }

      Dictionary<char, int> keyValuePairs= new Dictionary<char, int>();

      foreach (var post in posts)
      {
        foreach(var symbol in post.Text.ToLower())
        {
          if (keyValuePairs.ContainsKey(symbol))
          {
            keyValuePairs[symbol]++;
            continue;
          }

          keyValuePairs.Add(symbol, 1);
        }
      }

      var records = keyValuePairs
        .Select(e => new Record(ownerId, e.Key, e.Value))
        .OrderBy(e=> e.Char)
        .ToList();

      await _repository.AddRecordsAsync(records);
    }
  }
}
