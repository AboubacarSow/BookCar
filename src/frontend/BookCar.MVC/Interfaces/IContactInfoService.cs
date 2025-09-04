namespace BookCar.MVC.Interfaces;

public interface IContactInfoService
{
    Task<ContactInfoDto> GetContactInfo();
}
