using Newtonsoft.Json;
using System.Text;

namespace BookCar.MVC.Services;

internal class ContactService(IHttpClientFactory httpClientFactory) : IContactService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("BookCarApi");
    public async Task<bool> SendContactMessage(ContactDto createContactDto)
    {
        var jsonData = JsonConvert.SerializeObject(createContactDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        await _client.PostAsync("contacts", content);
        return true;
    }
}
