using BookCar.Application.Features.Mediator.Commands.Locations;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using MediatR;
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
