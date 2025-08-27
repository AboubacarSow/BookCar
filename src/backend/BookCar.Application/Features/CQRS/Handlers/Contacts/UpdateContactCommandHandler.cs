using BookCar.Application.Features.CQRS.Commands.Contacts;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Application.Features.CQRS.Handlers.Contacts;

public class UpdateContactCommandHandler 
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateContactCommand request)
    {
        var contact = new  Contact
        {
            Id = request.Id,
            Name = request.Name,
            Email = request.Email,
            Subject = request.Subject,
            Message = request.Message,
            SendDate = request.SendDate,
        }
        ;
        _unitOfWork.Contact.Update(contact);
        await _unitOfWork.SaveChangesAsync();
    }
}
