using BookCar.Application.Features.CQRS.Queries.Banners;
using BookCar.Application.Features.CQRS.Results.Banners;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Banners;

public class GetBannerByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public GetBannerByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
    {
        var banner = await _unitOfWork.Banner.GetOneByIdAsync(query.Id, false);
        if (banner == null) return null;

        return new GetBannerByIdQueryResult
        {
            Id = banner.Id,
            Title = banner.Title,
            Description = banner.Description,
            VideoDescription = banner.VideoDescription,
            VideoUrl = banner.VideoUrl,
        };
    }
}

