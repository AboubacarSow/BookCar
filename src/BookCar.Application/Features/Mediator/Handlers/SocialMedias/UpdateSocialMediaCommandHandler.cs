using BookCar.Application.Features.Mediator.Commands.SocialMedias;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.SocialMedias;

public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSocialMediaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var socialMedia = await _unitOfWork.SocialMedia.GetOneByIdAsync(request.Id,false);
        if (socialMedia == null)
        {
            throw new KeyNotFoundException("Social media not found.");
        }

        socialMedia.Name = request.Name;
        socialMedia.Url = request.Url;
        socialMedia.Icon = request.Icon;

        _unitOfWork.SocialMedia.Update(socialMedia);
        await _unitOfWork.SaveChangesAsync();
    }
}
