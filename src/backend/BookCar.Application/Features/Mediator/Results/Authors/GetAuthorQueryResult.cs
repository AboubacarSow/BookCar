namespace BookCar.Application.Features.Mediator.Results.Authors;

public class GetAuthorQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}

public class GetAuthorByIdQueryResult
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
