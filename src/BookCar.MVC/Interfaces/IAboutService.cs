using BookCar.MVC.Dtos.Abouts;

namespace BookCar.MVC.Interfaces;

public interface IAboutService 
{
    Task<GetAboutDto> GetAbout();
    
}
