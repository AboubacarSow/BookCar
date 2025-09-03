using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

internal class CommentRepository : RepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Comment comment)=>Add(comment);


    public async Task<IEnumerable<Comment>> GetAllAsync(bool trackChanges)
        => await FindAll(trackChanges).ToListAsync();


    public async Task<Comment> GetOneByIdAsync(int id, bool trackChanges)
        => await FindByCondition(c => c.Id == id, trackChanges).FirstOrDefaultAsync();

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

    public void Update(Comment comment)
    =>Edit(comment);
}