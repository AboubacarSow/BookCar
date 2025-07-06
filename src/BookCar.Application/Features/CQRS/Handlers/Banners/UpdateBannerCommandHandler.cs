using BookCar.Application.Features.CQRS.Commands.Banners;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Banners;

public class UpdateBannerCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBannerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateBannerCommand command)
    {
        var banner = await _unitOfWork.Banner.GetOneByIdAsync(command.Id, false);
        if (banner == null) throw new ArgumentException("Banner not found");

        banner.Title = command.Title;
        banner.Description = command.Description;
        banner.VideoDescription = command.VideoDescription;
        banner.VideoUrl = command.VideoUrl;

        _unitOfWork.Banner.Update(banner);
        await _unitOfWork.SaveChangesAsync();
    }
}   

