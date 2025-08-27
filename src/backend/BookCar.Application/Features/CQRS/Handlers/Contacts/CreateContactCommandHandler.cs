using BookCar.Application.Features.CQRS.Commands.Contacts;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Application.Features.CQRS.Handlers.Contacts;

public class CreateContactCommandHandler 
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateContactCommand request)
    {
        var contact = new Contact
        {
            Name = request.Name,
            Email = request.Email,
            Subject = request.Subject,
            Message = request.Message,
            SendDate = request.SendDate,
        };
        _unitOfWork.Contact.Create(contact);
        await _unitOfWork.SaveChangesAsync();

    }
}
