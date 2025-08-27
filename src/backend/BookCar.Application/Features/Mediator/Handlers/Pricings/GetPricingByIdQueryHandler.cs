using BookCar.Application.Features.Mediator.Queries.Pricings;
using BookCar.Application.Features.Mediator.Results.Pricings;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Pricings;

public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPricingByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
    {
        var pricing = await _unitOfWork.Pricing.GetOneByIdAsync(request.Id,false);
        if (pricing == null)
        {
            throw new KeyNotFoundException("Pricing not found.");
        }

        return new GetPricingByIdQueryResult(pricing.Id, pricing.Name);
    }
}