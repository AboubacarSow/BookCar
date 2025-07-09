using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface ISocialMediaRepository
{
    // Define any additional methods specific to SocialMedia if needed
    Task<IEnumerable<SocialMedia>> GetAllAsync(bool trackChanges);
    Task<SocialMedia> GetOneByIdAsync(int id, bool trackChanges);
    void Create(SocialMedia socialMedia);
    void Update(SocialMedia socialMedia);
    Task RemoveByIdAsync(int id);
}