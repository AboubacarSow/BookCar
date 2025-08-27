using BookCar.Application.Features.Mediator.Commands.FooterAddresses;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.FooterAddress;

public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFooterAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var footerAddress = await _unitOfWork.FooterAddress.GetOneByIdAsync(request.Id,false);
        if (footerAddress == null)
        {
            throw new KeyNotFoundException("Footer address not found.");
        }

        footerAddress.Description = request.Description;
        footerAddress.Address = request.Address;
        footerAddress.Phone = request.Phone;
        footerAddress.Email = request.Email;

        _unitOfWork.FooterAddress.Update(footerAddress);
        await _unitOfWork.SaveChangesAsync();


    }
}
