namespace BookCar.Domain.Entities;

public class Reservation : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int CarID { get; set; }
    public virtual Car Car { get; set; }
    public int Age { get; set; }
    public int DriverLicenseYear { get; set; }
    public string? Description { get; set; }
    public virtual Location? PickUpLocation { get; set; }
    public int? PickUpLocationID { get; set; }
    public virtual Location? DropOffLocation { get; set; }
    public int? DropOffLocationID { get; set; }
    public string Status { get; set; }
}
