namespace BookCar.MVC.Dtos;

public record BlogDto(int Id,
    string Title,
    AuthorDto Author,
    string CoverImageUrl,
    DateTime CreatedDate,
    CategoryDto Category,
    string Description,
    List<TagCloudDto> TagClouds,
    List<CommentDto> Comments);

public record AuthorDto(int Id,string Name,string ImageUrl,string Description);
public record CategoryDto(int Id, string Name);
public record TagCloudDto(int Id, string Title);
public record CommentDto(int Id, string Name, string Email, string Description, DateTime CreatedDate);