using Microsoft.AspNetCore.Mvc;

namespace BookCar.MVC.ViewComponents;

public class _FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
