using BookCar.Application.Features.CQRS.Queries.Contacts;
using BookCar.Application.Features.CQRS.Results.Contacts;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Contacts;

public class GetContactByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContactByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetContactByIdQueryResult?> Handle(GetContactByIdQuery request)
    {
        var contact = await _unitOfWork.Contact.GetOneByIdAsync(request.Id, false);
        return contact is null ? null : new GetContactByIdQueryResult(contact.Id, contact.Name, contact.Email, contact.Subject, contact.Message, contact.SendDate);
    }
}