namespace BookCar.Application.Features.Mediator.Handlers.Services;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Domain.Entities.Service
        {
            Title = request.Title,
            Description = request.Description,
            IconUrl = request.IconUrl
        };

        _unitOfWork.Service.Create(service);
        await _unitOfWork.SaveChangesAsync();

    }
}
public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _unitOfWork.Service.GetByIdAsync(request.Id);
        if (service == null) throw new NotFoundException("Service not found");

        service.Title = request.Title;
        service.Description = request.Description;
        service.IconUrl = request.IconUrl;

        _unitOfWork.Service.Update(service);
        await _unitOfWork.SaveChangesAsync();
    }
}
public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Service.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServiceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var services = await _unitOfWork.Service.GetAllAsync(false);
        return services.Select(s => new GetServiceQueryResult
        {
            Id = s.Id,
            Title = s.Title,
            Description = s.Description,
            IconUrl = s.IconUrl
        }).ToList();
    }
}
public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetServiceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _unitOfWork.Service.GetByIdAsync(request.Id);
        if (service == null)
        {
            throw new KeyNotFoundException("Service not found.");
        }

        return new GetServiceByIdQueryResult
        {
            Id = service.Id,
            Title = service.Title,
            Description = service.Description,
            IconUrl = service.IconUrl
        };
    }
}