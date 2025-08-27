using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

internal class ContactInfoRepository(BookCarDbContext context) 
    : RepositoryBase<ContactInfo>(context), IContactInfoRepository
{
    public void Create(ContactInfo contactInfo)
    => Add(contactInfo);

    public async Task<IEnumerable<ContactInfo>> GetAllAsync(bool trackChanges)
    =>await FindAll(trackChanges).ToListAsync();

    public async Task<ContactInfo> GetOneByIdAsync(int id, bool trackChanges)
    => await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

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

    public void Update(ContactInfo contactInfo)=>Edit(contactInfo);
    
}