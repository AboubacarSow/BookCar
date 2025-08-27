using BookCar.Application.Features.CQRS.Commands.Abouts;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Application.Features.CQRS.Handlers.Abouts;

public class UpdateAboutCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateAboutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAboutCommand request)
    {
        var about = new About
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
        };
        _unitOfWork.About.Update(about);
        await _unitOfWork.SaveChangesAsync();
    }
}
