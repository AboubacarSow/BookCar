using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Pricings;

public class CreatePricingCommand(string name) : IRequest
{
    public string Name { get; set; } = name;

}
