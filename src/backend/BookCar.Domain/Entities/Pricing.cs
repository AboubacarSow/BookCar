namespace BookCar.Domain.Entities;

public class Pricing : BaseEntity
{
    public string Name { get; set; }
    public virtual List<CarPricing> CarPricings { get; set; }
}
