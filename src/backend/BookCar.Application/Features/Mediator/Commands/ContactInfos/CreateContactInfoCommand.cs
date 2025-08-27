using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.ContactInfos;

public class CreateContactInfoCommand:IRequest<int>
{
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
public class UpdateContactInfoCommand : IRequest<int>
{
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
public class DeleteContactInfoCommand : IRequest<int>
{
    
}
