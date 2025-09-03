
using BookCar.Domain.Entities;
namespace BookCar.Application.Interfaces.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetAllAsync(bool trackChanges);
    Task<Comment> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Comment comment);
    void Update(Comment comment);
    Task RemoveByIdAsync(int id);
}
