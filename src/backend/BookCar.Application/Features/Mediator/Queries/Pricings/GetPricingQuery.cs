using BookCar.Application.Features.Mediator.Results.Pricings;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Pricings;

public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
{
}
public class GetPricingByIdQuery(int id) : IRequest<GetPricingByIdQueryResult>
{
    public int Id { get; set; } = id;
}