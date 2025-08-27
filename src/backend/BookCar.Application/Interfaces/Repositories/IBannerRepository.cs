
using BookCar.Domain.Entities;
namespace BookCar.Application.Interfaces.Repositories;

public interface IBannerRepository
{
    Task<IEnumerable<Banner>> GetAllAsync(bool trackChanges);
    Task<Banner> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Banner banner);
    void Update(Banner banner);
    Task RemoveByIdAsync(int id);
}
