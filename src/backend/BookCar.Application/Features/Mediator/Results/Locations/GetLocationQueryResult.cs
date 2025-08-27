namespace BookCar.Application.Features.Mediator.Results.Locations;

public class GetLocationQueryResult(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}
public class GetLocationByIdQueryResult(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}
