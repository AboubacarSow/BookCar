namespace BookCar.Domain.Entities;

public class ContactInfo : BaseEntity
{
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
