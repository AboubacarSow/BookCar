namespace BookCar.Application.Features.CQRS.Results.Categories;

public record GetCategoryQueryResult(int Id, string Name);

public class GetCategoryByIdQueryResult(int Id,string Name);
