using BookCar.Application.Features.Mediator.Commands.Pricings;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.Pricings;

public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePricingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
    {
        var pricing = new Pricing
        {
            Name = request.Name
        };

        _unitOfWork.Pricing.Create(pricing);
        await _unitOfWork.SaveChangesAsync();


    }
}
