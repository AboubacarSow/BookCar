using BookCar.Application.Features.CQRS.Commands.Categories;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Categories;

public class RemoveCategoryCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork= unitOfWork;
    }

    public async Task Handle(RemoveCategoryCommand request)
    {
        await _unitOfWork.Category.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}