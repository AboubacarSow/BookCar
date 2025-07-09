using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IServiceRepository
{
    // Define any additional methods specific to Service if needed
    Task<IEnumerable<Service>> GetAllAsync(bool trackChanges);
    Task<Service> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Service service);
    void Update(Service service);
    Task RemoveByIdAsync(int id);
}
