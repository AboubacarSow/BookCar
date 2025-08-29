using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCar.MVC.ViewComponents;

public class _FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

public class _BannerViewComponent(IBannerService bannerService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var banner = await bannerService.GetBanner();
        return View(banner);
    }
}
