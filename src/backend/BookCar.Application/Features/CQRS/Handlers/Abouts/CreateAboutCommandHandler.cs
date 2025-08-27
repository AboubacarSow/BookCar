using BookCar.Application.Features.CQRS.Commands.Abouts;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Application.Features.CQRS.Handlers.Abouts;

public class CreateAboutCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateAboutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateAboutCommand request)
    {
        var about = new About
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
        };
        _unitOfWork.About.Create(about);
        await _unitOfWork.SaveChangesAsync();
    }
}
