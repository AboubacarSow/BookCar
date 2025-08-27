using BookCar.Application.Features.CQRS.Commands.Banners;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Banners;

public class RemoveBannerCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveBannerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(RemoveBannerCommand command)
    {
       
        await _unitOfWork.Banner.RemoveByIdAsync(command.Id);
            await _unitOfWork.SaveChangesAsync();
    }
}

