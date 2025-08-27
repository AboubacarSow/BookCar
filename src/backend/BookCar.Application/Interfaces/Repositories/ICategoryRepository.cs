
using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync(bool trackChanges);
    Task<Category> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Category banner);
    void Update(Category banner);
    Task RemoveByIdAsync(int id);
}
