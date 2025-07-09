namespace BookCar.Application.Features.Mediator.Handlers.FooterAddress;

public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFooterAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var footerAddress = new FooterAddress
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

public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFooterAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var footerAddress = await _unitOfWork.FooterAddress.GetByIdAsync(request.Id);
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

        return Unit.Value;
    }
}
public class DeleteFooterAddressCommandHandler : IRequestHandler<DeleteFooterAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFooterAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteFooterAddressCommand request, CancellationToken cancellationToken)
    {
     

        await _unitOfWork.FooterAddress.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
        return Unit.Value;
    }
}
public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFooterAddressByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var footerAddress = await _unitOfWork.FooterAddress.GetByIdAsync(request.Id);
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
public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFooterAddressQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
        var footerAddresses = await _unitOfWork.FooterAddress.GetAllAsync();
        return footerAddresses.Select(f => new GetFooterAddressQueryResult(
            f.Id,
            f.Description,
            f.Address,
            f.Phone,
            f.Email
        )).ToList();
    }
}