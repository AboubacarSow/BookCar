using BookCar.Application.Features.Mediator.Commands.FooterAddresses;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.FooterAddress;

public class DeleteFooterAddressCommandHandler : IRequestHandler<DeleteFooterAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFooterAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFooterAddressCommand request, CancellationToken cancellationToken)
    {
     

        await _unitOfWork.FooterAddress.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();

    }
}
