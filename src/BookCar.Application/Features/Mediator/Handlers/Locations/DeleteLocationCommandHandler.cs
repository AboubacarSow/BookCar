using BookCar.Application.Features.Mediator.Commands.Locations;
using BookCar.Application.Interfaces.Repositories;
using MediatR;
namespace BookCar.Application.Features.Mediator.Handlers.Locations;

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
