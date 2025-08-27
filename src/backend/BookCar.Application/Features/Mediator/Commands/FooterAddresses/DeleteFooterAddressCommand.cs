using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.FooterAddresses;

public class DeleteFooterAddressCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}