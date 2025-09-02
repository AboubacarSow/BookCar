using BookCar.Application.Interfaces.Repositories;
using BookCar.Infrastructure.Persistence;

namespace BookCar.Infrastructure.Data;

internal class UnitOfWork : IUnitOfWork
{
    private readonly BookCarDbContext _context;
    private readonly Lazy<IAboutRepository> _aboutRepository;
    private readonly Lazy<IBannerRepository> _bannerRepository;
    private readonly Lazy<IBrandRepository> _brandRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<IContactRepository> _contactRepository;
    private readonly Lazy<ICarRepository> _carRepository;
    private readonly Lazy<IFeatureRepository> _featureRepository;
    private readonly Lazy<IFooterAddressRepository> _footerAddressRepository;
    private readonly Lazy<ILocationRepository> _locationRepository;
    private readonly Lazy<IPricingRepository> _priceRepository;
    private readonly Lazy<IServiceRepository> _serviceRepository;
    private readonly Lazy<ISocialMediaRepository> _socialMediaRepository;
    private readonly Lazy<ITestimonialRepository> _testimonialRepository;
    private readonly Lazy<IContactInfoRepository> _contactInfoRepository;
    private readonly Lazy<IBlogRepository> _blogRepository;

    public UnitOfWork(BookCarDbContext context, Lazy<IAboutRepository> aboutRepository,
       Lazy<IBannerRepository> bannerRepository, Lazy<IBrandRepository> brandRepository,
       Lazy<ICategoryRepository> categoryRepository, Lazy<IContactRepository> contactRepository,
       Lazy<ICarRepository> carRepository, Lazy<IFeatureRepository> featureRepository,
       Lazy<IFooterAddressRepository> footerAddressRepository, Lazy<ILocationRepository> locationRepository,
       Lazy<IPricingRepository> priceRepository, Lazy<IServiceRepository> serviceRepository,
       Lazy<ISocialMediaRepository> socialMediaRepository, Lazy<ITestimonialRepository> testimonialRepository
        , Lazy<IContactInfoRepository> contactInfoRepository, Lazy<IBlogRepository> blogRepository)
    {
        _context = context;
        _aboutRepository = aboutRepository;
        _bannerRepository = bannerRepository;
        _brandRepository = brandRepository;
        _categoryRepository = categoryRepository;
        _contactRepository = contactRepository;
        _carRepository = carRepository;
        _featureRepository = featureRepository;
        _footerAddressRepository = footerAddressRepository;
        _locationRepository = locationRepository;
        _priceRepository = priceRepository;
        _serviceRepository = serviceRepository;
        _socialMediaRepository = socialMediaRepository;
        _testimonialRepository = testimonialRepository;
        _contactInfoRepository = contactInfoRepository;
        _blogRepository = blogRepository;
    }

    public IAboutRepository About => _aboutRepository.Value;
    public IBannerRepository Banner => _bannerRepository.Value;
    public IBrandRepository Brand => _brandRepository.Value;
    public ICategoryRepository Category => _categoryRepository.Value;
    public IContactRepository Contact => _contactRepository.Value;
    public ICarRepository Car => _carRepository.Value;
    public IFeatureRepository Feature => _featureRepository.Value;
    public IFooterAddressRepository FooterAddress => _footerAddressRepository.Value;
    public ILocationRepository Location => _locationRepository.Value;
    public IServiceRepository Service => _serviceRepository.Value;
    public IPricingRepository Pricing => _priceRepository.Value;
    public ISocialMediaRepository SocialMedia => _socialMediaRepository.Value;
    public ITestimonialRepository Testimonial => _testimonialRepository.Value;
    public IContactInfoRepository ContactInfo => _contactInfoRepository.Value;
    public IBlogRepository Blog => _blogRepository.Value;

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    
}
