using BookCar.Application.Features.Mediator.Commands.SocialMedias;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.SocialMedias;

public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSocialMediaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var socialMedia = new SocialMedia
        {
            Name = request.Name,
            Url = request.Url,
            Icon = request.Icon
        };

        _unitOfWork.SocialMedia.Create(socialMedia);
        await _unitOfWork.SaveChangesAsync();

    }
}
