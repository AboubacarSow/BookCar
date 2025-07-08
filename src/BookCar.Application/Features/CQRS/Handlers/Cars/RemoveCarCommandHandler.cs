using BookCar.Application.Features.CQRS.Commands.Cars;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Cars;

public class RemoveCarCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public RemoveCarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveCarCommand request)
    {
        await _unitOfWork.Car.RemoveByIdAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}

