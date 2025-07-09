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
        var pricing = new Domain.Entities.Pricing
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        _unitOfWork.Pricing.Create(pricing);
        await _unitOfWork.SaveChangesAsync();


    }
}
public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePricingCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
    {
        var pricing = await _unitOfWork.Pricing.GetByIdAsync(request.Id);
        if (pricing == null)
        {
            throw new KeyNotFoundException("Pricing not found.");
        }

        pricing.Name = request.Name;
        pricing.Description = request.Description;
        pricing.Price = request.Price;

        _unitOfWork.Pricing.Update(pricing);
        await _unitOfWork.SaveChangesAsync();
    }
}
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
public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPricingQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
    {
        var pricings = await _unitOfWork.Pricing.GetAllAsync(false);
        return pricings.Select(p => new GetPricingQueryResult(p.Id, p.Name, p.Description, p.Price)).ToList();
    }
}
public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPricingByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
    {
        var pricing = await _unitOfWork.Pricing.GetByIdAsync(request.Id);
        if (pricing == null)
        {
            throw new KeyNotFoundException("Pricing not found.");
        }

        return new GetPricingByIdQueryResult(pricing.Id, pricing.Name, pricing.Description, pricing.Price);
    }
}