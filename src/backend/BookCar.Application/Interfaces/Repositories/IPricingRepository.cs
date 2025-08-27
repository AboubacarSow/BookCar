using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IPricingRepository
{
    // Define any additional methods specific to Pricing if needed
    Task<IEnumerable<Pricing>> GetAllAsync(bool trackChanges);
    Task<Pricing> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Pricing pricing);
    void Update(Pricing pricing);
    Task RemoveByIdAsync(int id);
}
