using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

internal class SocialMediaRepository : RepositoryBase<SocialMedia>, ISocialMediaRepository
{
    public SocialMediaRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(SocialMedia socialMedia) => Add(socialMedia);
    public async Task<IEnumerable<SocialMedia>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
    public async Task<SocialMedia> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(sm => sm.Id == id, trackChanges).FirstOrDefaultAsync();
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
    public void Update(SocialMedia socialMedia) => Edit(socialMedia);
}