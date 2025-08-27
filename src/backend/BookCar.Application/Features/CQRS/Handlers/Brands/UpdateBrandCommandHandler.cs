using BookCar.Application.Features.CQRS.Commands.Brands;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Brands;

public class UpdateBrandCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBrandCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateBrandCommand request)
    {
        var brand = await _unitOfWork.Brand.GetOneByIdAsync(request.Id, false);
        if (brand is null) return;

        brand.Name = request.Name;
       
        _unitOfWork.Brand.Update(brand);
        await _unitOfWork.SaveChangesAsync();
    }
}
