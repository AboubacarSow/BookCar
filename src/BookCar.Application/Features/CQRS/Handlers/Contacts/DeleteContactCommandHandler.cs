using BookCar.Application.Features.CQRS.Commands.Contacts;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Contacts;

public class DeleteContactCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteContactCommand request)
    {
            await _unitOfWork.Contact.RemoveByIdAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
    }
}
