using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCar.Domain.Entities;

public class RentACarProcess : BaseEntity
{
    public Car? Car { get; set; }
    public int CarID { get; set; }
    public int PickUpLocation { get; set; }
    public int DropOffLocation { get; set; }

    [Column(TypeName = "Date")]
    public DateTime PickUpDate { get; set; }

    [Column(TypeName = "Date")]
    public DateTime DropOffDate { get; set; }

    [DataType(DataType.Time)]
    public TimeSpan PickUpTime { get; set; }

    [DataType(DataType.Time)]
    public TimeSpan DropOffTime { get; set; }
    public Customer? Customer { get; set; }
    public int CustomerID { get; set; }
    public string PickUpDescription { get; set; }
    public string DropOffDescription { get; set; }
    public decimal TotalPrice { get; set; }
}
