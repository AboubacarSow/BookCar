using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Locations;

public class CreateLocationCommand : IRequest
{
    public string Name { get; set; } 

}
