namespace BookCar.Domain.Entities;

public class Customer : BaseEntity
{
    public string CustomerName { get; set; }
    public string CustomerSurname { get; set; }
    public string CustomerMail { get; set; }
    public List<RentACarProcess> RentACarProcesses { get; set; }
}
