namespace BookCar.Domain.Entities;

public class Review : BaseEntity
{
    public string CustomerName { get; set; }
    public string CustomerImage { get; set; }
    public string Comment { get; set; }
    public int RatingValue { get; set; }
    public DateTime ReviewDate { get; set; }
    public virtual Car? Car { get; set; }
    public int CarID { get; set; }
}
