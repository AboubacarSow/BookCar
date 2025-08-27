using BookCar.Application.Features.CQRS.Commands.Categories;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Application.Features.CQRS.Handlers.Categories;

public class UpdateCategoryCommandHandler 
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand request)
    {

        _unitOfWork.Category.Update(new Category { Name = request.Name });
        await _unitOfWork.SaveChangesAsync();
    }
}
