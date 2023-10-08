using GetPostsApp.Domain.Entities;

namespace GetPostsApp.Domain.Repositories
{
  public interface IRepository
  {
    Task AddRecordsAsync(IEnumerable<Record> records);
  }
}
