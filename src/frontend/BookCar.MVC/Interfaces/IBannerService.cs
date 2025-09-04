namespace BookCar.MVC.Interfaces;

public interface IBannerService
{
    Task<BannerDto> GetBanner();
}
