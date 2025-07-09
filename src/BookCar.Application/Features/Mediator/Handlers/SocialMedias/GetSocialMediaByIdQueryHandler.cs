using BookCar.Application.Features.Mediator.Queries.SocialMedias;
using BookCar.Application.Features.Mediator.Results.SocialMedias;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.SocialMedias;

public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSocialMediaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var socialMedia = await _unitOfWork.SocialMedia.GetOneByIdAsync(request.Id,false);
        if (socialMedia == null)
        {
            throw new KeyNotFoundException("Social media not found.");
        }

        return new GetSocialMediaByIdQueryResult(socialMedia.Id, socialMedia.Name, socialMedia.Icon, socialMedia.Icon);
        
    }
}