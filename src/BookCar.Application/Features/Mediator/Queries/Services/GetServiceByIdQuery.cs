using BookCar.Application.Features.Mediator.Results.Services;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Services;

public class GetServiceByIdQuery(int id) : IRequest<GetServiceByIdQueryResult>
{
    public int Id { get; set; } = id;
}