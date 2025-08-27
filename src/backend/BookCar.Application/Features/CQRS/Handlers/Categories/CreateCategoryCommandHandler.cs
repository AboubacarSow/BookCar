using BookCar.Application.Features.CQRS.Commands.Categories;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Application.Features.CQRS.Handlers.Categories;
public class CreateCategoryCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand request)
    {
        var category = new Category { Name = request.Name };
         _unitOfWork.Category.Create(category);
        await _unitOfWork.SaveChangesAsync();
    }
}
