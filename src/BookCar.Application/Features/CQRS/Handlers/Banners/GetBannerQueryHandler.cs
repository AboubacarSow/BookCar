using BookCar.Application.Features.CQRS.Results.Banners;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Banners;

public class GetBannerQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public GetBannerQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetBannerQueryResult>> Handle()
    {
        var banner = await _unitOfWork.Banner.GetAllAsync(false);
        return [.. banner.Select(b => new GetBannerQueryResult
        {
            Id = b.Id,
            Title = b.Title,
            Description = b.Description,
            VideoDescription = b.VideoDescription,
            VideoUrl = b.VideoUrl,
        })];

    }
}

