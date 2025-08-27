using BookCar.Application.Features.Mediator.Commands.ContactInfos;
using BookCar.Application.Features.Mediator.Queries.ContactInfos;
using BookCar.Application.Features.Mediator.Results.ContactInfos;
using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using MediatR;

namespace BookCar.Application.Features.Mediator.Handlers.ContactInfos;

public class CreateContactInfoCommandHandler(IUnitOfWork unitOfwork) : IRequestHandler<CreateContactInfoCommand,int>
{
    public async Task<int> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
    {
        var contactInfo = new ContactInfo
        {
            Address = request.Address,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
        };
        unitOfwork.ContactInfo.Create(contactInfo);
        await unitOfwork.SaveChangesAsync();
        return contactInfo.Id;
    }
}

public class GetContactInfoCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetContactInfosQuery, List<GetContactInfosQueryResult>>
{
    public async Task<List<GetContactInfosQueryResult>> Handle(GetContactInfosQuery request, CancellationToken cancellationToken)
    {
        var contactInfos = await unitOfWork.ContactInfo.GetAllAsync(false);
        var dtos= contactInfos.Select( c=> new GetContactInfosQueryResult
        {
            Address= c.Address,
            Email= c.Email,
            PhoneNumber= c.PhoneNumber,
        }).ToList();

        return dtos;
    }
}
