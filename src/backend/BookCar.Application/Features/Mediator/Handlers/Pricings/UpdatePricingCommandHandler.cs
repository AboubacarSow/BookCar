using BookCar.Application.Features.Mediator.Commands.Pricings;
using BookCar.Application.Interfaces.Repositories;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Pricings;

public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePricingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
    {
        var pricing = await _unitOfWork.Pricing.GetOneByIdAsync(request.Id,false);
        if (pricing == null)
        {
            throw new KeyNotFoundException("Pricing not found.");
        }

        pricing.Name = request.Name;
        
        _unitOfWork.Pricing.Update(pricing);
        await _unitOfWork.SaveChangesAsync();
    }
}
