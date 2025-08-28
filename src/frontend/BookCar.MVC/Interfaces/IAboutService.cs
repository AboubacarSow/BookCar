
using BookCar.MVC.Dtos.Abouts;

namespace BookCar.MVC.Interfaces;

public interface IAboutService
{
    Task<GetAboutDto> GetAbout();
}


public interface ITestimonialService
{
    Task<List<TestimonialDto>> GetTestimonials();
}
public interface IHizmetService
{
    Task<List<HizmetDto>> GetHizmetler();
}
public interface IContactInfoService
{
    Task<ContactInfoDto> GetContactInfo();
} 

public interface IContactService
{
    Task<bool> SendContactMessage(ContactDto createContactDto);
}
