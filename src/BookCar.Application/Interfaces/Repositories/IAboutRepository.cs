using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IAboutRepository
{
    Task<IEnumerable<About>> GetAllAsync(bool trackChanges);
    Task<About> GetOneByIdAsync(int id, bool trackChanges);
    void Create(About about);
    void Update(About about);
    Task RemoveByIdAsync(int id);

    
}
