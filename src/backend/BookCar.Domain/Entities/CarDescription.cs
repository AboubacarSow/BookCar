namespace BookCar.Domain.Entities;

public class CarDescription : BaseEntity
{
    public virtual Car? Car { get; set; }
    public int CarID { get; set; }
    public string Details { get; set; }
}
