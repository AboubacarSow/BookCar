namespace BookCar.Application.Features.Mediator.Results.Pricings;

public class GetPricingQueryResult(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}
public class GetPricingByIdQueryResult(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}