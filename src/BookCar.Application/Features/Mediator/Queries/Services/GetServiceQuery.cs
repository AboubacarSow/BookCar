namespace BookCar.Application.Features.Mediator.Queries.Services;

public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
{
}
public class GetServiceByIdQuery(int id) : IRequest<GetServiceByIdQueryResult>
{
    public int Id { get; set; } = id;
}