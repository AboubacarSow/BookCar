using BookCar.Application.Features.Mediator.Results.Locations;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Locations;

public class GetLocationByIdQuery(int id) : IRequest<GetLocationByIdQueryResult>
{
    public int Id { get; set; } = id;
}