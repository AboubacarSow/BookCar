

using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IContactInfoRepository
{
    Task<IEnumerable<ContactInfo>> GetAllAsync(bool trackChanges);

    Task<ContactInfo> GetOneByIdAsync(int id, bool trackChanges);
    void Create(ContactInfo contactInfo);

    void Update(ContactInfo contactInfo);
    Task RemoveByIdAsync(int id);

}
