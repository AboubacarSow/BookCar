using Microsoft.Extensions.DependencyInjection;

namespace BookCar.Infrastructure.Extensions;

public class LazyFactory<T> : Lazy<T>
{
    public LazyFactory(IServiceProvider serviceProvider)
        : base(() => serviceProvider.GetRequiredService<T>())
    {
    }
}