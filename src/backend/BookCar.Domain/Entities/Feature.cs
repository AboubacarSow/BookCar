namespace BookCar.Domain.Entities;

public class Feature : BaseEntity
{
    public string Name { get; set; }
    public virtual List<CarFeature> CarFeatures { get; set; }
}
