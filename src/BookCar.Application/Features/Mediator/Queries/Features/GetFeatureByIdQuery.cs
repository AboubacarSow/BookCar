using BookCar.Application.Features.Mediator.Results.Features;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.Features;

public class GetFeatureByIdQuery(int id) :IRequest<GetFeatureByIdQueryResult>
{
    public int Id { get; set; } = id;
}
