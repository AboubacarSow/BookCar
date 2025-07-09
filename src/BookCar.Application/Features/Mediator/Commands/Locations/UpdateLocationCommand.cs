using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Locations;

public class UpdateLocationCommand : IRequest
{
    public int Id { get; set; } 
    public string Name { get; set; } 
}
