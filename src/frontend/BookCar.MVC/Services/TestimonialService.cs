using Newtonsoft.Json;

namespace BookCar.MVC.Services;

internal class TestimonialService(IHttpClientFactory httpClientFactory, ILogger<TestimonialService> logger)
: ITestimonialService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("BookCarApi");

    public async Task<List<TestimonialDto>> GetTestimonials()
    {
        var result = await _client.GetAsync("testimonials");
        var jsonData = await result.Content.ReadAsStringAsync();

        var testimonials = JsonConvert.DeserializeObject<List<TestimonialDto>>(jsonData);

        return testimonials ?? [];
    }


}
