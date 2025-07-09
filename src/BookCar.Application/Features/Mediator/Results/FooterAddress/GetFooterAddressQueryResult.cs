namespace BookCar.Application.Features.Mediator.Results.FooterAddress;

public class GetFooterAddressQueryResult(int id, string description, string address, string phone, string email)
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;
    public string Address { get; set; } = address;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
}

public class GetFooterAddressByIdQueryResult(int id, string description, string address, string phone, string email)
{
    public int Id { get; set; } = id;
    public string Description { get; set; } = description;
    public string Address { get; set; } = address;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
}