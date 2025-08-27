namespace BookCar.Domain.Entities;

public class RentACar : BaseEntity
{
    public int LocationID { get; set; }
    public Location Location { get; set; }
    public Car? Car { get; set; }
    public int CarID { get; set; }
    public bool Available { get; set; }
}
