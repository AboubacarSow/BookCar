using BookCar.Domain.Entities;

namespace BookCar.Application.Features.Mediator.Results.Comments;

public  class GetCommentQueryResult
{
    public int Id { get; set; } 
    public string Name { get; set; }=string.Empty;
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public Blog? Blog { get; set; }
    public int BlogID { get; set; }
}
