using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

internal class PricingRepository(BookCarDbContext context) : RepositoryBase<Pricing>(context), IPricingRepository
{
    public void Create(Pricing pricing) => Add(pricing);
    public async Task<IEnumerable<Pricing>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
    public async Task<Pricing> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(p => p.Id == id, trackChanges).FirstOrDefaultAsync();
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
    public void Update(Pricing pricing) => Edit(pricing);
}
