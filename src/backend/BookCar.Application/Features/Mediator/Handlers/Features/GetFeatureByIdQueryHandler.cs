using BookCar.Application.Features.Mediator.Queries.Features;
using BookCar.Application.Features.Mediator.Results.Features;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Features;

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFeatureByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var feature= await _unitOfWork.Feature.GetOneByIdAsync(request.Id,false);
        return new GetFeatureByIdQueryResult
        {
            Id = feature.Id,
            Name = feature.Name,

        };
    }
}
