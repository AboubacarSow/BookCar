using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace BookCar.Infrastructure.Data.Repositories;

public class FooterAddressRepository : RepositoryBase<FooterAddress>, IFooterAddressRepository
{
    public FooterAddressRepository(BookCarDbContext dbContext) : base(dbContext)
    {
    }
    
    public void Create(FooterAddress footerAddress)=>Add(footerAddress);
    

    public async Task<IEnumerable<FooterAddress>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<FooterAddress> GetOneByIdAsync(int id, bool trackChanges)
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

    public void Update(FooterAddress footerAddress)=>Edit(footerAddress);
    
}