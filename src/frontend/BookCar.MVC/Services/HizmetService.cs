using Newtonsoft.Json;

namespace BookCar.MVC.Services;

internal class HizmetService(IHttpClientFactory httpClientFactory):IHizmetService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("BookCarApi");
    
    public async Task<List<HizmetDto>> GetHizmetler()
    {
        var result = await _client.GetAsync("services");
        var jsonData = await result.Content.ReadAsStringAsync();

        var hizmetler = JsonConvert.DeserializeObject<List<HizmetDto>>(jsonData);

        return hizmetler ?? [];
    }
}
