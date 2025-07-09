namespace BookCar.Infrastructure.Data.Repositories;

public class LocationRepository : RepositoryBase<Location>, ILocationRepository
{
    public LocationRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Location location) => Create(location);
    public async Task<IEnumerable<Location>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
    public async Task<Location> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(l => l.Id == id, trackChanges).FirstOrDefaultAsync();
    }
    public async Task RemoveByIdAsync(int id)
    {
        var model = await GetOneByIdAsync(id, false);
        if (model == null)
        {
            throw new ArgumentException("Item does not found");
        }
        else
        {
            Remove(model);
        }
    }
    public void Update(Location location) => Update(location);
}
public class PricingRepository : RepositoryBase<Pricing>, IPricingRepository
{
    public PricingRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Pricing pricing) => Create(pricing);
    public async Task<IEnumerable<Pricing>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
    public async Task<Pricing> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(p => p.Id == id, trackChanges).FirstOrDefaultAsync();
    }
    public async Task RemoveByIdAsync(int id)
    {
        var model = await GetOneByIdAsync(id, false);
        if (model == null)
        {
            throw new ArgumentException("Item does not found");
        }
        else
        {
            Remove(model);
        }
    }
    public void Update(Pricing pricing) => Update(pricing);
}
public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Service service) => Create(service);
    public async Task<IEnumerable<Service>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
    public async Task<Service> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(s => s.Id == id, trackChanges).FirstOrDefaultAsync();
    }
    public async Task RemoveByIdAsync(int id)
    {
        var model = await GetOneByIdAsync(id, false);
        if (model == null)
        {
            throw new ArgumentException("Item does not found");
        }
        else
        {
            Remove(model);
        }
    }
    public void Update(Service service) => Update(service);
}
public class SocialMediaRepository : RepositoryBase<SocialMedia>, ISocialMediaRepository
{
    public SocialMediaRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(SocialMedia socialMedia) => Create(socialMedia);
    public async Task<IEnumerable<SocialMedia>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
    public async Task<SocialMedia> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(sm => sm.Id == id, trackChanges).FirstOrDefaultAsync();
    }
    public async Task RemoveByIdAsync(int id)
    {
        var model = await GetOneByIdAsync(id, false);
        if (model == null)
        {
            throw new ArgumentException("Item does not found");
        }
        else
        {
            Remove(model);
        }
    }
    public void Update(SocialMedia socialMedia) => Update(socialMedia);
}