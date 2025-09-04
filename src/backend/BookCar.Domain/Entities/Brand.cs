namespace BookCar.Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; }
    public virtual List<Car> Cars { get; set; }
}
