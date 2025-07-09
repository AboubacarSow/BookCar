using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

public class LocationRepository : RepositoryBase<Location>, ILocationRepository
{
    public LocationRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Location location) => Add(location);
    public async Task<IEnumerable<Location>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
    public async Task<Location> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(l => l.Id == id, trackChanges).FirstOrDefaultAsync();
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
    public void Update(Location location) => Edit(location);
}
