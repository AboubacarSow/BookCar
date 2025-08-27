using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Pricings;

public class DeletePricingCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}