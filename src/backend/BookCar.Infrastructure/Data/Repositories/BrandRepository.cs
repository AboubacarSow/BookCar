using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;
internal class BrandRepository : RepositoryBase<Brand>, IBrandRepository
{
    public BrandRepository(BookCarDbContext context) : base(context)
    {
    }
    public void Create(Brand brand) => Add(brand);

    public async Task<IEnumerable<Brand>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<Brand> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(b => b.Id == id, trackChanges).FirstOrDefaultAsync();
    }

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

    public void Update(Brand brand) => Edit(brand);
}