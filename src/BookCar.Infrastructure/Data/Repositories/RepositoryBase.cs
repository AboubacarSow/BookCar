using BookCar.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookCar.Infrastructure.Data.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly BookCarDbContext _context;

    protected RepositoryBase(BookCarDbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Edit(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public IQueryable<T> FindAll(bool trackCkanges)
    {
        return !trackCkanges
             ? _context.Set<T>().AsNoTracking()
             : _context.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
    {
        return !trackChanges
            ? _context.Set<T>().Where(condition).AsNoTracking() 
            : _context.Set<T>().Where(condition);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}
