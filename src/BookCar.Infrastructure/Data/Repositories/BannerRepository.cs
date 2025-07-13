using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

internal class BannerRepository : RepositoryBase<Banner>, IBannerRepository
{
    public BannerRepository(BookCarDbContext context) : base(context)
    {
    }
    public void Create(Banner banner) => Add(banner);

    public async Task<IEnumerable<Banner>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<Banner> GetOneByIdAsync(int id, bool trackChanges)
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

    public void Update(Banner banner) => Edit(banner);
}