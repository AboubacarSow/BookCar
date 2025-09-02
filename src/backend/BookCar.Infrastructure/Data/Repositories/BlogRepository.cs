using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;

namespace BookCar.Infrastructure.Data.Repositories;

public class BlogRepository : IBlogRepository
{
    public void Create(Blog blog)=>Add(blog);
    

    public async Task<IEnumerable<Blog>> GetAllAsync(bool trackChanges)
        =>await FindAll(trackChanges).ToListAsync();

    public async Task<Blog> GetOneByIdAsync(int id, bool trackChanges)
    =>await FindByCondition(b=>b.Id==id,trackChanges).FirstOrDefaultAsync();

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

    public void Update(Blog blog)
   => Edit(blog);
}
