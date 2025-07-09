using BookCar.Domain.Entities;

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
