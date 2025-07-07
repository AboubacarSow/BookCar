namespace BookCar.Application.Features.CQRS.Results.Brands;

public class GetBrandByIdQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public GetBrandByIdQueryResult(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
