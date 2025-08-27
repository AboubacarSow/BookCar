using BookCar.Application.Features.Mediator.Results.FooterAddress;
using MediatR;

namespace BookCar.Application.Features.Mediator.Queries.FooterAddress;


public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
{

}
