using BookCar.Application.Features.CQRS.Commands.Brands;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Brands;

public class DeleteBrandCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteBrandCommand request)
    {
 
        await _unitOfWork.Brand.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}   