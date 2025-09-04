using Newtonsoft.Json;

namespace BookCar.MVC.Services;

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
