

using BookCar.Application.Features.CQRS.Handlers.Abouts;
using Microsoft.Extensions.DependencyInjection;

namespace BookCar.Application.DependencyInjection;

public static class DIContainer
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<GetAboutQueryHandler>();
        services.AddScoped<GetAboutByIdQueryHandler>();
        services.AddScoped<CreateAboutCommandHandler>();
        services.AddScoped<UpdateAboutCommandHandler>();
        services.AddScoped<RemoveAboutCommandHandler>();
    }
}
