using BookCar.Application.Features.Mediator.Queries.Pricings;
using BookCar.Application.Features.Mediator.Results.Pricings;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Pricings;

public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPricingQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
    {
        var pricings = await _unitOfWork.Pricing.GetAllAsync(false);
        return [.. pricings.Select(p => new GetPricingQueryResult(p.Id, p.Name))];
    }
}
