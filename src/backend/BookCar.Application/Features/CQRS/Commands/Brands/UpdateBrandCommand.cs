namespace BookCar.Application.Features.CQRS.Commands.Brands;

public class UpdateBrandCommand
{
    public int Id { get; set; } 
    public string Name { get; set; }
}
