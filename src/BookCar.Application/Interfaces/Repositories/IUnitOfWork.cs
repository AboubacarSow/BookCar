namespace BookCar.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    IAboutRepository About { get; }

    IBannerRepository Banner { get; }
    IBrandRepository Brand { get; }
    ICategoryRepository Category { get; }
    IContactRepository Contact { get; }
    ICarRepository Car { get; }
    IFeatureRepository Feature { get; }

    Task SaveChangesAsync();
}
