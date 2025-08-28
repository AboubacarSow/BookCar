using BookCar.MVC.Dtos.Abouts;
using BookCar.MVC.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Text;

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

internal class ContactInfoService(IHttpClientFactory httpClientFactory):IContactInfoService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("BookCarApi");
    public async Task<ContactInfoDto> GetContactInfo()
    {
        var result = await _httpClient.GetAsync("contactInfos");
        var jsonData = await result.Content.ReadAsStringAsync();
        var contactInfo = JsonConvert.DeserializeObject<List<ContactInfoDto>>(jsonData)?.FirstOrDefault();
        return contactInfo!;
    }
}

internal class ContactService(IHttpClientFactory httpClientFactory) : IContactService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("BookCarApi");
    public async Task<bool> SendContactMessage(ContactDto createContactDto)
    {
        var jsonData= JsonConvert.SerializeObject(createContactDto);
        var content= new StringContent(jsonData,Encoding.UTF8,"application/json");
         await _client.PostAsync("contacts",content);
        return true;
    }
}
