using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.SocialMedias;

public class DeleteSocialMediaCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
