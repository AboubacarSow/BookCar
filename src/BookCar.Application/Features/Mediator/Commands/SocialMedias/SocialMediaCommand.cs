using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.SocialMedias;

public class CreateSocialMediaCommand: IRequest
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; } 
        
}
