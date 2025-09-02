using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetAllAsync(bool trackChanges);
  //  Task<IEnumerable<Blog>> GetAllWithAuthorCategoryTagCloudsCommentsAsync(bool trackChanges);
    Task<Blog> GetOneByIdAsync(int id, bool trackChanges);
    void Create(Blog blog);
    void Update(Blog blog);
    Task RemoveByIdAsync(int id);

}
