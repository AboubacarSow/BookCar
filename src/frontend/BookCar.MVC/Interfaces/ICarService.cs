
using BookCar.MVC.Dtos.Abouts;

namespace BookCar.MVC.Interfaces;

public interface ICarService
{
    Task<List<CarWithBrandDto>> GetCarsWithBrand();
}
