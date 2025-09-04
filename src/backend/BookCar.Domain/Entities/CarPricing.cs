namespace BookCar.Domain.Entities;

public class CarPricing : BaseEntity
{
    public virtual Car? Car { get; set; }
    public int CarID { get; set; }
    public virtual Pricing? Pricing { get; set; }
    public int PricingID { get; set; }
    public decimal Amount { get; set; }
}
