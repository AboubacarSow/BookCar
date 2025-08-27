using BookCar.MVC.Dtos.Abouts;
using BookCar.MVC.Interfaces;
using Newtonsoft.Json;

namespace BookCar.MVC.Services;

public class AboutService(IHttpClientFactory httpClientFactory, ILogger<AboutService> logger) : IAboutService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("BookCarApi");

    public async Task<GetAboutDto> GetAbout()
    {
        var result =await  _client.GetAsync("abouts");
        var jsonData =await  result.Content.ReadAsStringAsync();

        var about = (JsonConvert.DeserializeObject<List<GetAboutDto>>(jsonData))?.FirstOrDefault();
        
        return about!;
    }
}
