namespace BookCar.Domain.Entities;

public class FooterAddress : BaseEntity
{
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}