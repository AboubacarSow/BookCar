using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllAsync(bool trackChanges);
    Task<IEnumerable<Car>> GetAllWithBrandAsync(bool trackChanges);
    Task<Car> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Car car);
    void Update(Car car);
    Task RemoveByIdAsync(int id);

}
