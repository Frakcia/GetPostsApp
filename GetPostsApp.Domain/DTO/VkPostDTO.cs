namespace GetPostsApp.Domain.DTO
{
  public class VkPostDTO
  {
    public int Id { get; set; }
    public long OwnerId { get; set; }
    public long FromId { get; set; }
    public string Text { get; set; }
  }
}
