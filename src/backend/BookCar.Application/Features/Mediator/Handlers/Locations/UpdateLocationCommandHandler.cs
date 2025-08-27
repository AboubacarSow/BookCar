using BookCar.Application.Features.Mediator.Commands.Locations;
using BookCar.Application.Interfaces.Repositories;
using MediatR;
namespace BookCar.Application.Features.Mediator.Handlers.Locations;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _unitOfWork.Location.GetOneByIdAsync(request.Id,false);
        location.Name = request.Name;
        _unitOfWork.Location.Update(location);
        await _unitOfWork.SaveChangesAsync();
    }
}
