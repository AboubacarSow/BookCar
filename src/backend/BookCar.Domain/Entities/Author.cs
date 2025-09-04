namespace BookCar.Domain.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public virtual List<Blog>? Blogs { get; set; }
}
