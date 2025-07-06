using BookCar.Application.Features.CQRS.Results.Abouts;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Abouts;

public class GetAboutQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAboutQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var abouts = await _unitOfWork.About.GetAllAsync(false);
        return [.. abouts.Select(a => new GetAboutQueryResult
        {
            Id = a.Id,
            Title = a.Title,    
            Description = a.Description,
            ImageUrl = a.ImageUrl, 
        })];
    }
}
