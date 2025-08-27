using BookCar.Application.Features.Mediator.Commands.Pricings;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Pricings;

public class DeletePricingCommandHandler : IRequestHandler<DeletePricingCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePricingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePricingCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Pricing.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
