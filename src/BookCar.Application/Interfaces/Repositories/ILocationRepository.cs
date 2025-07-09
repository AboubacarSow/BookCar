namespace BookCar.Application.Interfaces.Repositories;

public interface ILocationRepository
{
    // Define any additional methods specific to Location if needed
    Task<IEnumerable<Location>> GetAllAsync(bool trackChanges);
    Task<Location> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Location location);
    void Update(Location location);
    Task RemoveByIdAsync(int id);
}
public interface IServiceRepository
{
    // Define any additional methods specific to Service if needed
    Task<IEnumerable<Service>> GetAllAsync(bool trackChanges);
    Task<Service> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Service service);
    void Update(Service service);
    Task RemoveByIdAsync(int id);
}
public interface IPricingRepository
{
    // Define any additional methods specific to Pricing if needed
    Task<IEnumerable<Pricing>> GetAllAsync(bool trackChanges);
    Task<Pricing> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Pricing pricing);
    void Update(Pricing pricing);
    Task RemoveByIdAsync(int id);
}
public interface ISocialMediaRepository
{
    // Define any additional methods specific to SocialMedia if needed
    Task<IEnumerable<SocialMedia>> GetAllAsync(bool trackChanges);
    Task<SocialMedia> GetOneByIdAsync(int id, bool trackChanges);
    void Create(SocialMedia socialMedia);
    void Update(SocialMedia socialMedia);
    Task RemoveByIdAsync(int id);
}