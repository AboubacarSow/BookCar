using BookCar.Application.Features.Mediator.Commands.FooterAddresses;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.FooterAddresses;

public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFooterAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var footerAddress = new Domain.Entities.FooterAddress
        {
            Description = request.Description,
            Address = request.Address,
            Phone = request.Phone,
            Email = request.Email
        };

        _unitOfWork.FooterAddress.Create(footerAddress);
        await _unitOfWork.SaveChangesAsync();


    }
}
