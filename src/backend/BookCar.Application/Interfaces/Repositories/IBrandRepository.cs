using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllAsync(bool trackChanges);
    Task<Brand> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Brand brand);
    void Update(Brand brand);
    Task RemoveByIdAsync(int id);
}
