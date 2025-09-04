using Newtonsoft.Json;

namespace BookCar.MVC.Services;

internal class BannerService(IHttpClientFactory httpClientFactory) : IBannerService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("BookCarApi");
    public async Task<BannerDto> GetBanner()
    {
        var result = await _client.GetAsync("banners");
        var jsonData = await result.Content.ReadAsStringAsync();
        var banner = JsonConvert.DeserializeObject<List<BannerDto>>(jsonData)?.FirstOrDefault();
        return banner!;
    }
}
