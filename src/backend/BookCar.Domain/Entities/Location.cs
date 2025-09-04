namespace BookCar.Domain.Entities;

public class Location : BaseEntity
{
    public string Name { get; set; }
    public virtual List<RentACar> RentACars { get; set; }
    public virtual List<Reservation> PickUpReservations { get; set; }
    public virtual List<Reservation> DropOffReservations { get; set; }
}
