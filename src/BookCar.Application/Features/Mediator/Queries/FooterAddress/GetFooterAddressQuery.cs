namespace BookCar.Application.Features.Mediator.Queries.FooterAddress;


public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
{

}
public class GetFooterAddressByIdQuery(int id):IRequest<GetFooterAddressByIdQueryResult>
{
    public int Id { get; set; } = id;
}
