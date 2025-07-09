using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Service service) => Add(service);
    public async Task<IEnumerable<Service>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
    public async Task<Service> GetOneByIdAsync(int id, bool trackChanges)
    {
        return await FindByCondition(s => s.Id == id, trackChanges).FirstOrDefaultAsync();
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
    public void Update(Service service) => Edit(service);
}
