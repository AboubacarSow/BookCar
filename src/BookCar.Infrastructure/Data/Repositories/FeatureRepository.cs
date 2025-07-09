using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

public class FeatureRepository :RepositoryBase<Feature>, IFeatureRepository
{
    public FeatureRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Feature feature)=>Add(feature);
    

    public async Task<IEnumerable<Feature>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<Feature> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(f => f.Id == id, trackChanges).FirstOrDefaultAsync();
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

    public void Update(Feature feature)=>Edit(feature);
    
}
