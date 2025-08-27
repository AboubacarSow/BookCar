using BookCar.Application.Features.CQRS.Commands.Brands;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Application.Features.CQRS.Handlers.Brands;

public class CreateBrandCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateBrandCommand request)
    {
        var brand = new Brand { Name = request.Name };
        _unitOfWork.Brand.Create(brand);
        await _unitOfWork.SaveChangesAsync();
    }
}
