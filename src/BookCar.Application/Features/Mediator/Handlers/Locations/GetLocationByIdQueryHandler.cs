using BookCar.Application.Features.Mediator.Queries.Locations;
using BookCar.Application.Features.Mediator.Results.Locations;
using BookCar.Application.Interfaces.Repositories;
using MediatR;
namespace BookCar.Application.Features.Mediator.Handlers.Locations;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLocationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var location = await _unitOfWork.Location.GetOneByIdAsync(request.Id, false);
        return new GetLocationByIdQueryResult(location.Id, location.Name);
    }
}