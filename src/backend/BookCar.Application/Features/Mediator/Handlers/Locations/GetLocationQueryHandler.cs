using BookCar.Application.Features.Mediator.Queries.Locations;
using BookCar.Application.Features.Mediator.Results.Locations;
using BookCar.Application.Interfaces.Repositories;
using MediatR;
namespace BookCar.Application.Features.Mediator.Handlers.Locations;

public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLocationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var locations = await _unitOfWork.Location.GetAllAsync(false);
        return locations.Select(l => new GetLocationQueryResult(l.Id, l.Name)).ToList();
    }
}
