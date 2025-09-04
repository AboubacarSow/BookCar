using BookCar.Application.Features.CQRS.Queries.Categories;
using BookCar.Application.Features.CQRS.Results.Categories;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Categories;

public class GetCategoryByIdQueryHandler 
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request)
    {
        var category = await _unitOfWork.Category.GetOneByIdAsync(request.Id, false);
        return new GetCategoryByIdQueryResult(category.Id, category.Name);
        
    }
}
