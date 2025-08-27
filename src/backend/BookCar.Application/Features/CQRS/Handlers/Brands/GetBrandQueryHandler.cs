using BookCar.Application.Features.CQRS.Results.Brands;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Brands;

public class GetBrandQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBrandQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetBrandQueryResult>> Handle()
    {
        var brands = await _unitOfWork.Brand.GetAllAsync(false);
        return [.. brands.Select(b => new GetBrandQueryResult(b.Id, b.Name))];
    }
}
