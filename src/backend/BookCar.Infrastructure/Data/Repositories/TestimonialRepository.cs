using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;
internal class TestimonialRepository(BookCarDbContext context)
        : RepositoryBase<Testimonial>(context), ITestimonialRepository
{
    public async Task<IEnumerable<Testimonial>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<Testimonial> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(t => t.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
    }

    public void Create(Testimonial testimonial)=>Add(testimonial);
    

    public void Update(Testimonial testimonial)=> Edit(testimonial);
    

    public async Task RemoveByIdAsync(int id)
    {
       var model = await GetOneByIdAsync(id, false);
        if (model == null)
        {
            throw new ArgumentException("Item does not found");
        }
        else
        {
            Remove(model);
        }
    }
}
