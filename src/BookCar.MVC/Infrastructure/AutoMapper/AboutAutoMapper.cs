using AutoMapper;
using BookCar.MVC.Dtos.Abouts;
using BookCar.MVC.Models;

namespace BookCar.MVC.Infrastructure.AutoMapper;

public class AboutAutoMapper:Profile
{
    public AboutAutoMapper()
    {
        CreateMap<GetAboutDto, AboutViewModel>();
    }
}
