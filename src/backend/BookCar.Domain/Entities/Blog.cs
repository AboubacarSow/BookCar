namespace BookCar.Domain.Entities;

public class Blog : BaseEntity
{
    public string Title { get; set; }
    public virtual Author? Author { get; set; }
    public int AuthorID { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual Category? Category { get; set; }
    public int CategoryID { get; set; }
    public string Description { get; set; }
    public virtual List<TagCloud> TagClouds { get; set; }
    public virtual List<Comment> Comments { get; set; }
}
