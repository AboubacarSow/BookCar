using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookCarDbContext _context;
    private readonly IAboutRepository _aboutRepository;
    private readonly IBannerRepository _bannerRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IContactRepository _contactRepository;
    private readonly ICarRepository _carRepository;
    private readonly IFeatureRepository _featureRepository;
    private readonly IFooterAddressRepository _footerAddressRepository;

    public UnitOfWork(IAboutRepository aboutRepository, BookCarDbContext context,
       IBannerRepository bannerRepository, IBrandRepository brandRepository,
       ICategoryRepository categoryRepository, IContactRepository contactRepository,
       ICarRepository carRepository, IFeatureRepository featureRepository, IFooterAddressRepository footerAddressRepository)
    {
        _aboutRepository = aboutRepository;
        _context = context;
        _bannerRepository = bannerRepository;
        _brandRepository = brandRepository;
        _categoryRepository = categoryRepository;
        _contactRepository = contactRepository;
        _carRepository = carRepository;
        _featureRepository = featureRepository;
        _footerAddressRepository = footerAddressRepository;
    }

    public IAboutRepository About => _aboutRepository;
    public IBannerRepository Banner => _bannerRepository;
    public IBrandRepository Brand => _brandRepository;
    public ICategoryRepository Category => _categoryRepository;
    public IContactRepository Contact => _contactRepository;
    public ICarRepository Car => _carRepository;
    public IFeatureRepository Feature => _featureRepository;
    public IFooterAddressRepository FooterAddress => _footerAddressRepository;

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    
}
