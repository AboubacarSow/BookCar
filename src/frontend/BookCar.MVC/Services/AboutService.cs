using BookCar.MVC.Dtos.Abouts;
using Newtonsoft.Json;

namespace BookCar.MVC.Services;

internal class AboutService(IHttpClientFactory httpClientFactory, ILogger<AboutService> logger) : IAboutService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("BookCarApi");

    public async Task<GetAboutDto> GetAbout()
    {
        var result = await _client.GetAsync("abouts");
        var jsonData = await result.Content.ReadAsStringAsync();

        var about = JsonConvert.DeserializeObject<List<GetAboutDto>>(jsonData)?.FirstOrDefault();

        return about!;
    }
}
internal class BlogService(IHttpClientFactory httpClientFactory) 
: IBlogService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("BookCarApi");

    public async Task<List<BlogDto>> GetLastThreeBlogs()
    {
        var result = await _client.GetAsync("blogs/lastThreeblogs");
        var jsonData = await result.Content.ReadAsStringAsync();

        var blog = JsonConvert.DeserializeObject<List<BlogDto>>(jsonData);

        return blog!;
    }
}