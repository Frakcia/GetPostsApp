using GetPostsApp.Domain.Entities;
using GetPostsApp.Domain.Repositories;

namespace GetPostsApp.Infrastructure.Repositories
{
  public class Repository : IRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task AddRecordsAsync(IEnumerable<Record> records)
    {
      await _dbContext.AddRangeAsync(records);
      await _dbContext.SaveChangesAsync();
    }
  }
}
