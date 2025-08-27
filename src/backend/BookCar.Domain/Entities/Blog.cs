namespace BookCar.Domain.Entities;

public class Blog : BaseEntity
{
    public string Title { get; set; }
    public Author? Author { get; set; }
    public int AuthorID { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public Category? Category { get; set; }
    public int CategoryID { get; set; }
    public string Description { get; set; }
    public List<TagCloud> TagClouds { get; set; }
    public List<Comment> Comments { get; set; }
}
