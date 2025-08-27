using BookCar.Application.Features.CQRS.Results.Contacts;
using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Application.Features.CQRS.Handlers.Contacts;

public class GetContactQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContactQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetContactQueryResult>> Handle()
    {
        var contacts = await _unitOfWork.Contact.GetAllAsync(false);
        return contacts.Select(c => new GetContactQueryResult(c.Id, c.Name, c.Email, c.Subject, c.Message, c.SendDate)).ToList();
    }
}
