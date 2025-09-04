using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.Authors;

public class UpdateAuthorCommand:IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}

