using BookCar.Domain.Entities;

namespace BookCar.Application.Interfaces.Repositories;

public interface IFooterAddressRepository 
{
    // Define any additional methods specific to FooterAddress if needed
    Task<IEnumerable<FooterAddress>> GetAllAsync(bool trackChanges);
    Task<FooterAddress> GetOneByIdAsync(int id, bool trackChanges);
    void Create(FooterAddress footerAddress);
    void Update(FooterAddress footerAddress);
    Task RemoveByIdAsync(int id);
}