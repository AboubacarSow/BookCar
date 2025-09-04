namespace BookCar.MVC.Interfaces;

public interface IHizmetService
{
    Task<List<HizmetDto>> GetHizmetler();
}
