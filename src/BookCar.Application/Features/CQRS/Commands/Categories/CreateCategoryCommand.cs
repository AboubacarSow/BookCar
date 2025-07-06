namespace BookCar.Application.Features.CQRS.Commands.Categories;

public class CreateCategoryCommand
{
    public string Name { get; set; }

    // Additional properties can be added as needed
}
public record RemoveCategoryCommand(int Id);
public class UpdateCategoryCommand
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Additional properties can be added as needed
}