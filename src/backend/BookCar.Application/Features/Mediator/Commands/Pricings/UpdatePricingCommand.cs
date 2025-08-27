using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Pricings;

public class UpdatePricingCommand: IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
