namespace BookCar.Application.Features.Mediator.Commands.Pricings;

public class CreatePricingCommand(string name) : IRequest
{
    public string Name { get; set; } = name;

}
public class UpdatePricingCommand: IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class DeletePricingCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}