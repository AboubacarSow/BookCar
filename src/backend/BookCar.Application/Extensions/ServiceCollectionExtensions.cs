

using BookCar.Application.Features.CQRS.Handlers.Abouts;
using BookCar.Application.Features.CQRS.Handlers.Banners;
using BookCar.Application.Features.CQRS.Handlers.Brands;
using BookCar.Application.Features.CQRS.Handlers.Cars;
using BookCar.Application.Features.CQRS.Handlers.Categories;
using Microsoft.Extensions.DependencyInjection;

namespace BookCar.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        // About Handlers Registration
        services.AddScoped<GetAboutQueryHandler>();
        services.AddScoped<GetAboutByIdQueryHandler>();
        services.AddScoped<CreateAboutCommandHandler>();
        services.AddScoped<UpdateAboutCommandHandler>();
        services.AddScoped<RemoveAboutCommandHandler>();
        
        // Banner Handlers Registration
        services.AddScoped<GetBannerQueryHandler>();
        services.AddScoped<GetBannerByIdQueryHandler>();
        services.AddScoped<CreateBannerCommandHandler>();
        services.AddScoped<UpdateBannerCommandHandler>();
        services.AddScoped<RemoveBannerCommandHandler>();
        
        // Brand Handlers Registration
        services.AddScoped<GetBrandQueryHandler>();
        services.AddScoped<GetBrandByIdQueryHandler>();
        services.AddScoped<CreateBrandCommandHandler>();
        services.AddScoped<UpdateBrandCommandHandler>();
        services.AddScoped<DeleteBrandCommandHandler>();

        // Category Handlers Registration
        services.AddScoped<GetCategoryQueryHandler>();
        services.AddScoped<GetCategoryByIdQueryHandler>();
        services.AddScoped<CreateCategoryCommandHandler>();
        services.AddScoped<UpdateCategoryCommandHandler>();
        services.AddScoped<RemoveCategoryCommandHandler>();

        // Car Handlers Registration
        services.AddScoped<GetCarQueryHandler>();
        services.AddScoped<GetCarByIdQueryHandler>();
        services.AddScoped<GetCarWithBrandQueryHandler>();
        services.AddScoped<CreateCarCommandHandler>();
        services.AddScoped<UpdateCarCommandHandler>();
        services.AddScoped<RemoveCarCommandHandler>();

        

        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
    }
}
