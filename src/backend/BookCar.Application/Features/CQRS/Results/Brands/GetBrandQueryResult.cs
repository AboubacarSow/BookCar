namespace BookCar.Application.Features.CQRS.Results.Brands;

public class GetBrandQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; }

    public GetBrandQueryResult(int id, string name)
    {
        Id = id; Name = name;
    }
}
