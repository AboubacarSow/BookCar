using BookCar.MVC.Dtos.Abouts;
using Newtonsoft.Json;

namespace BookCar.MVC.Services;

internal class CarService(IHttpClientFactory httpClientFactory) : ICarService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("BookCarApi");
    public async Task<List<CarWithBrandDto>> GetCarsWithBrand()
    {
        var result = await _client.GetAsync("cars/withbrand");
        var jsonData = await result.Content.ReadAsStringAsync();
        var cars = JsonConvert.DeserializeObject<List<CarWithBrandDto>>(jsonData);
        return cars ?? [];
    }
}
