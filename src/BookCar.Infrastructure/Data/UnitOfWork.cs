using BookCar.Application.Interfaces.Repositories;

namespace BookCar.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly IAboutRepository _aboutRepository;
    private readonly BookCarDbContext _context;
    private readonly IBannerRepository _bannerRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UnitOfWork(IAboutRepository aboutRepository, BookCarDbContext context,
                      IBannerRepository bannerRepository, IBrandRepository brandRepository,
                      ICategoryRepository categoryRepository)
    {
        _aboutRepository = aboutRepository;
        _context = context;
        _bannerRepository = bannerRepository;
        _brandRepository = brandRepository;
        _categoryRepository = categoryRepository;
    }

    public IAboutRepository About => _aboutRepository;
    public IBannerRepository Banner => _bannerRepository;
    public IBrandRepository Brand => _brandRepository;
    public ICategoryRepository Category => _categoryRepository;

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    
}
