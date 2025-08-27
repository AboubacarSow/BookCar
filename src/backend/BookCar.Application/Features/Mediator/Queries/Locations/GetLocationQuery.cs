using BookCar.Application.Features.Mediator.Results.Locations;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Locations;

public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
{
}
