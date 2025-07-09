namespace BookCar.Application.Features.Mediator.Commands.FooterAddress;

public class CreateFooterAddressCommand(string description, string address, string phone, string email) : IRequest
{
    public string Description { get; set; } = description;
    public string Address { get; set; } = address;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;


}
public class UpdateFooterAddressCommand(int id, string description, string address, string phone, string email) : IRequest
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;
    public string Address { get; set; } = address;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
}
public class DeleteFooterAddressCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}