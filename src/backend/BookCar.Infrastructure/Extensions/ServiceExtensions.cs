using BookCar.Application.Interfaces.Repositories;
using BookCar.Infrastructure.Data;
using BookCar.Infrastructure.Data.Repositories;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookCar.Infrastructure.Extensions;
public static class ServiceExtensions
{

    public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<BookCarDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        //Repository
        services.AddScoped<IAboutRepository, AboutRepository>();
        services.AddScoped<IBannerRepository, BannerRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IFeatureRepository, FeatureRepository>();
        services.AddScoped<IFooterAddressRepository, FooterAddressRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IPricingRepository, PricingRepository>();
        services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
        services.AddScoped<ITestimonialRepository, TestimonialRepository>();
        services.AddTransient(typeof(Lazy<>),typeof(LazyFactory<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
   
}
