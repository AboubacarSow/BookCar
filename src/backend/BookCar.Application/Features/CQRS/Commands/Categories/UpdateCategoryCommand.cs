namespace BookCar.Application.Features.CQRS.Commands.Categories;

public class UpdateCategoryCommand
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Additional properties can be added as needed
}