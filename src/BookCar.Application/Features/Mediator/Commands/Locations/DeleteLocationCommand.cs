using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Locations;

public class DeleteLocationCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}