using BookCar.Application.Features.CQRS.Results.Categories;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Categories;

public class GetCategoryQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var categories=await _unitOfWork.Category.GetAllAsync(false);
        return [.. categories.Select(c=> new GetCategoryQueryResult {
            Id = c.Id,  
            Name = c.Name,
        })];

    }
}
