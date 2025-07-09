using BookCar.Doomain.Entities;
namespace BookCar.Application.Features.Mediator.Handlers.Locations;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = new Location
        {
            Name = request.Name
        };

        _unitOfWork.Location.Create(location);
        await _unitOfWork.SaveChangesAsync();
    }
}
public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _unitOfWork.Location.GetByIdAsync(request.Id);
        if (location == null) throw new NotFoundException("Location not found");

        location.Name = request.Name;

        _unitOfWork.Location.Update(location);
        await _unitOfWork.SaveChangesAsync();
    }
}
public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Location.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLocationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var locations = await _unitOfWork.Location.GetAllAsync(false);
        return locations.Select(l => new GetLocationQueryResult(l.Id, l.Name)).ToList();
    }
}
public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLocationByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var location = await _unitOfWork.Location.GetByIdAsync(request.Id);
        if (location == null) throw new NotFoundException("Location not found");

        return new GetLocationByIdQueryResult(location.Id, location.Name);
    }
}