namespace GetPostsApp.Domain.Entities
{
  public class Record
  {
    public Record() {}
    public Record(long ownerId, char @char, int count)
    {
      OwnerId = ownerId;
      Char = @char;
      Count = count;
    }

    public int Id { get; set; }
    public long OwnerId { get; set; }
    public char Char { get; set; }
    public int Count { get; set; }
  }
}
