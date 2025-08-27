namespace BookCar.Domain.Entities;

public class CarFeature : BaseEntity
{
    public Car? Car { get; set; }
    public int CarID { get; set; }
    public Feature? Feature { get; set; }
    public int FeatureID { get; set; }
    public bool Available { get; set; }
}
