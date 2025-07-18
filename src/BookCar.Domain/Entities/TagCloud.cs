namespace BookCar.Domain.Entities;

public class TagCloud : BaseEntity
{
    public string Title { get; set; }
    public Blog? Blog { get; set; }
    public int BlogID { get; set; }
}
