

using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync(bool trackChanges);
    Task<Contact> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Contact contact);
    void Update(Contact contact);
    Task RemoveByIdAsync(int id);
}
