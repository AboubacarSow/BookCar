using BookCar.Application.Dtos;
using BookCar.Application.Features.CQRS.Results.Categories;
using BookCar.Application.Features.Mediator.Results.Authors;
using BookCar.Application.Features.Mediator.Results.Comments;

namespace BookCar.Application.Features.Mediator.Results.Blogs;

public record GetBlogsQueryResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public GetAuthorQueryResult? Author { get; set; }
    public int AuthorID { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public GetCategoryQueryResult? Category { get; set; }
    public int CategoryID { get; set; }
    public string Description { get; set; }
    public List<TagCloudDto> TagClouds { get; set; }
    public List<GetCommentQueryResult> Comments { get; set; }
}

public record GetBlogByIdQueryResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public GetAuthorQueryResult? Author { get; set; }
    public int AuthorID { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public GetCategoryQueryResult? Category { get; set; }
    public int CategoryID { get; set; }
    public string Description { get; set; }
    public List<TagCloudDto> TagClouds { get; set; }
    public List<GetCommentQueryResult> Comments { get; set; }
}
public record GetThreeLastBlogsQueryResult(int Id,
    string Title,
    GetAuthorQueryResult Author,
    string CoverImageUrl,
    DateTime CreatedDate,
    GetCategoryQueryResult Category,
    string Description,
    List<TagCloudDto> TagClouds,
    List<GetCommentQueryResult> Comments);
