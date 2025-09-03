using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

internal class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Author author)=>Add(author);
    

    public async Task<IEnumerable<Author>> GetAllAsync(bool trackChanges)
        =>await FindAll(trackChanges).ToListAsync();

    public async Task<Author> GetOneByIdAsync(int id, bool trackChanges)
      => await FindByCondition(b => b.Id == id, trackChanges).FirstOrDefaultAsync();

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

    public void Update(Author author)
      => Edit(author);
}
