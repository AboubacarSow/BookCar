namespace BookCar.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public virtual List<Blog> Blogs { get; set; }
}
