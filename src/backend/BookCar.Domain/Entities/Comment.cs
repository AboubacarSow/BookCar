namespace BookCar.Domain.Entities;

public class Comment : BaseEntity
{
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public Blog? Blog { get; set; }
    public int BlogID { get; set; }
}
