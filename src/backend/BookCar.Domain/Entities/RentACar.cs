namespace BookCar.Domain.Entities;

public class RentACar : BaseEntity
{
    public int LocationID { get; set; }
    public virtual Location Location { get; set; }
    public virtual Car? Car { get; set; }
    public int CarID { get; set; }
    public bool Available { get; set; }
}
