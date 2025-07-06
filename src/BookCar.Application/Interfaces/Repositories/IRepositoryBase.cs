using System.Linq.Expressions;

namespace BookCar.Application.Interfaces.Repositories;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> FindAll(bool trackCkanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition,bool trackChanges);

    void Add(T entity);
    void Edit(T entity);
    void Remove(T entity);
}
