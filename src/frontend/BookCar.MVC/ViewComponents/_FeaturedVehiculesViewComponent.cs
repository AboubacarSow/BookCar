using Microsoft.AspNetCore.Mvc;

namespace BookCar.MVC.ViewComponents;

public class _FeaturedVehiculesViewComponent(ICarService carService): ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cars=(await carService.GetCarsWithBrand()).Take(6).ToList();
        return View(cars);
    }
}
