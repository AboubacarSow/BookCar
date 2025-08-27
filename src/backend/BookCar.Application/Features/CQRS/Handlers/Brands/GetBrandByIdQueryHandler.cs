using BookCar.Application.Features.CQRS.Queries.Brands;
using BookCar.Application.Features.CQRS.Results.Brands;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Brands;

public class GetBrandByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBrandByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetBrandQueryResult?> Handle(GetBrandByIdQuery request)
    {
        var brand = await _unitOfWork.Brand.GetOneByIdAsync(request.Id, false);
        return brand is null ? null : new GetBrandQueryResult(brand.Id, brand.Name);
    }
}
