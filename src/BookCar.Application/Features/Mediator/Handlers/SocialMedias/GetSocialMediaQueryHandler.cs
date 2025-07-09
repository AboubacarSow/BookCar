using BookCar.Application.Features.Mediator.Queries.SocialMedias;
using BookCar.Application.Features.Mediator.Results.SocialMedias;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.SocialMedias;

public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSocialMediaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var socialMedias = await _unitOfWork.SocialMedia.GetAllAsync(false);
        return [.. socialMedias.Select(sm => new GetSocialMediaQueryResult(sm.Id,sm.Name,sm.Icon,sm.Url))];
    }
}
