namespace BookCar.Application.Mediator.Queries.Pricings;

public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
{
}
public class GetPricingByIdQuery(int id) : IRequest<GetPricingByIdQueryResult>
{
    public int Id { get; set; } = id;
}