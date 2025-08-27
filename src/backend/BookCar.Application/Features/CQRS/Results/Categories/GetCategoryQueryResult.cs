namespace BookCar.Application.Features.CQRS.Results.Categories;

public class GetCategoryQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Additional properties can be added as needed
}
public class GetCategoryByIdQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Additional properties can be added as needed
}