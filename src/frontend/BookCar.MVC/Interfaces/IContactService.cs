namespace BookCar.MVC.Interfaces;

public interface IContactService
{
    Task<bool> SendContactMessage(ContactDto createContactDto);
}
