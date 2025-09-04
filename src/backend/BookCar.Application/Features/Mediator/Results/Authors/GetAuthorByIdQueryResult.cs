namespace BookCar.Application.Features.Mediator.Results.Authors;

public record GetAuthorByIdQueryResult(int Id,string Name,string ImageUrl,string Description);

