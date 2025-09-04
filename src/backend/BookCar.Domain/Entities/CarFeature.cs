namespace BookCar.Domain.Entities;

public class CarFeature : BaseEntity
{
    public virtual Car? Car { get; set; }
    public int CarID { get; set; }
    public virtual Feature? Feature { get; set; }
    public int FeatureID { get; set; }
    public bool Available { get; set; }
}
