using MediatR;

namespace BookCar.Application.Features.Mediator.Commands.FooterAddresses;

public class UpdateFooterAddressCommand(int id, string description, string address, string phone, string email) : IRequest
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;
    public string Address { get; set; } = address;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
}
