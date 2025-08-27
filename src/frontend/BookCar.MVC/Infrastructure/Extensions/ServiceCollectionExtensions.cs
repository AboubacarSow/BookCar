using System.Net.Http.Headers;

namespace BookCar.MVC.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApiSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
        services.AddHttpClient("BookCarApi", client =>
        {
            var apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
            client.BaseAddress = new Uri(apiSettings?.BaseUrl ?? String.Empty);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

    }

    public static void ConfigureApiServices(this IServiceCollection services)
    {
        services.AddScoped<IAboutService, AboutService>();
        services.AddScoped<ITestimonialService, TestimonialService>();
        services.AddScoped<IHizmetService, HizmetService>();
        services.AddScoped<IContactInfoService, ContactInfoService>();
    }
}
