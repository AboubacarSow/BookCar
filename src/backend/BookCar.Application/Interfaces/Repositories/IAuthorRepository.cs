using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync(bool trackChanges);
    Task<Author> GetOneByIdAsync(int id, bool trackChanges);
    void Update(Author author);
    Task RemoveByIdAsync(int id);
    void Create(Author author);
}
