using BookCar.Application.Features.Mediator.Results.Services;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Services;

public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
{
}
