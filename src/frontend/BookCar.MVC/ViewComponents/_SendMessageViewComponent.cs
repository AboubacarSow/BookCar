using Microsoft.AspNetCore.Mvc;

namespace BookCar.MVC.ViewComponents;

public class _SendMessageViewComponent : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}