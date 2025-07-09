namespace BookCar.Application.Features.Mediator.Queries.Locations;

public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
{
}
public class GetLocationByIdQuery(int id) : IRequest<GetLocationByIdQueryResult>
{
    public int Id { get; set; } = id;
}