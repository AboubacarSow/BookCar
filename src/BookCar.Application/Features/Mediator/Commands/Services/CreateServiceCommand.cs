using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Services;

public class CreateServiceCommand : IRequest
{
    public string Title { get; set; } 
    public string Description { get; set; }  
    public string IconUrl { get; set; } 

}
