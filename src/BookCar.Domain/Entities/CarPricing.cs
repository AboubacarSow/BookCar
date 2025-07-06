namespace BookCar.Domain.Entities;

public class CarPricing : BaseEntity
{
    public Car? Car { get; set; }
    public int CarID { get; set; }
    public Pricing? Pricing { get; set; }
    public int PricingID { get; set; }
    public decimal Amount { get; set; }
}
