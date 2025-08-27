using BookCar.Application.Features.Mediator.Queries.FooterAddress;
using BookCar.Application.Features.Mediator.Results.FooterAddress;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.FooterAddresses;

public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFooterAddressQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
        var footerAddresses = await _unitOfWork.FooterAddress.GetAllAsync(false);
        return [.. footerAddresses.Select(f => new GetFooterAddressQueryResult(
            f.Id,
            f.Description,
            f.Address,
            f.Phone,
            f.Email
        ))];
    }
}