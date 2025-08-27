using BookCar.Application.Features.CQRS.Queries;
using BookCar.Application.Features.CQRS.Queries.Abouts;
using BookCar.Application.Features.CQRS.Results.Abouts;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Abouts;

public class GetAboutByIdQueryHandler
{
    private readonly IUnitOfWork _unitofWork;
    public GetAboutByIdQueryHandler(IUnitOfWork unitofWork)
    {
        _unitofWork = unitofWork;
    }

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request)
    {
        var about = await _unitofWork.About
            .GetOneByIdAsync(request.Id,false);
        return new GetAboutByIdQueryResult
        {
            Id = about.Id,
            Title = about.Title,
            Description = about.Description,
            ImageUrl = about.ImageUrl,  
        };
    }
}
