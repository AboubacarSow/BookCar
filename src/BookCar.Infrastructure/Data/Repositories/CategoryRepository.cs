using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;
public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Category category) => Add(category);

    public async Task<IEnumerable<Category>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<Category> GetOneByIdAsync(int id, bool trackChanges)
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

    public void Update(Category category) => Edit(category);
}