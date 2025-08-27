using BookCar.Application.Features.Mediator.Results.FooterAddress;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.FooterAddress;

public class GetFooterAddressByIdQuery(int id):IRequest<GetFooterAddressByIdQueryResult>
{
    public int Id { get; set; } = id;
}
