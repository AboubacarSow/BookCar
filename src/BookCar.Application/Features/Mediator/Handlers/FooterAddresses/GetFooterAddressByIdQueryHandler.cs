using BookCar.Application.Features.Mediator.Queries.FooterAddress;
using BookCar.Application.Features.Mediator.Results.FooterAddress;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.FooterAddress;

public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFooterAddressByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var footerAddress = await _unitOfWork.FooterAddress.GetOneByIdAsync(request.Id,false);
        if (footerAddress == null)
        {
            throw new KeyNotFoundException("Footer address not found.");
        }

        return new GetFooterAddressByIdQueryResult(
            footerAddress.Id,
            footerAddress.Description,
            footerAddress.Address,
            footerAddress.Phone,
            footerAddress.Email
        );
    }
}
