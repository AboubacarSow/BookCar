using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface ITestimonialRepository
{
    Task<IEnumerable<Testimonial>> GetAllAsync(bool trackChanges);
    Task<Testimonial> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Testimonial testimonial);
    void Update(Testimonial testimonial);
    Task RemoveByIdAsync(int id);
}