using BookCar.Application.Interfaces.Repositories;
using BookCar.Infrastructure.Data;
using BookCar.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookCar.Infrastructure.DependencyInjection;
public static class ServiceExtensions
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<BookCarDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
    public static void ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IAboutRepository, AboutRepository>();
        services.AddScoped<IBannerRepository, BannerRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IFeatureRepository, FeatureRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}