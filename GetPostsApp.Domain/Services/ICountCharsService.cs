namespace GetPostsApp.Domain.Services
{
  public interface ICountCharsService
  {
    Task CountsPostsChar(long ownerId);
  }
}
