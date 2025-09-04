using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

internal class BlogRepository : RepositoryBase<Blog>, IBlogRepository
{
    public BlogRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Blog blog)=>Add(blog);
    

    public async Task<IEnumerable<Blog>> GetAllAsync(bool trackChanges)
        =>await FindAll(trackChanges).ToListAsync();

    public async Task<Blog> GetOneByIdAsync(int id, bool trackChanges)
    =>await FindByCondition(b=>b.Id==id,trackChanges).FirstOrDefaultAsync();

    public Task<List<Blog>> GetThreeLastBlogsAsync(bool trackChanges)
    {
        return FindAll(trackChanges).OrderByDescending(b=>b.Id).Take(3).ToListAsync();
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

    public void Update(Blog blog)
   => Edit(blog);
}
