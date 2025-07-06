using BookCar.Application.Features.CQRS.Commands.Banners;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Application.Features.CQRS.Handlers.Banners;

public class CreateBannerCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBannerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateBannerCommand command)
    {
        var banner = new Banner
        {
            Title = command.Title,
            Description = command.Description,
            VideoDescription = command.VideoDescription,
            VideoUrl = command.VideoUrl,
        };

        _unitOfWork.Banner.Create(banner);
        await _unitOfWork.SaveChangesAsync();

        return banner.Id;
    }
}

