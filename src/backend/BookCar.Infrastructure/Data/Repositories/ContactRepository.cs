using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;
internal class ContactRepository : RepositoryBase<Contact>, IContactRepository
{
    public ContactRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Contact contact) => Add(contact);

    public async Task<IEnumerable<Contact>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<Contact> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(c => c.Id == id, trackChanges).FirstOrDefaultAsync();
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

    public void Update(Contact contact) => Edit(contact);
}