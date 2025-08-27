using BookCar.Application.Features.Mediator.Queries.Features;
using BookCar.Application.Features.Mediator.Results.Features;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Features;

public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetFeatureQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        var features = await _unitOfWork.Feature.GetAllAsync(false);
        return [.. features.Select(x => new GetFeatureQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        })];
    }
}
