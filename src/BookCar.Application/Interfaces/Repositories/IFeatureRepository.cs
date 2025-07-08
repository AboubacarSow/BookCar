using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IFeatureRepository
{
    Task<IEnumerable<Feature>> GetAllAsync(bool trackChanges);
    Task<Feature> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Feature feature);
    void Update(Feature feature);
    Task RemoveByIdAsync(int id);
}
