using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using BookCar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookCar.Infrastructure.Data.Repositories;

internal class CarRepository : RepositoryBase<Car>, ICarRepository
{
    public CarRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(Car car)=>Add(car);
    

    public async Task<IEnumerable<Car>> GetAllAsync(bool trackChanges)
    {

        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetAllWithBrandAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).Include(b=>b.Brand).ToListAsync();
    }

    public async Task<Car> GetOneByIdAsync(int id, bool trackChanges)
    {
       return await FindByCondition(c => c.Id == id, trackChanges).FirstAsync();

    }

    public async Task RemoveByIdAsync(int id)
    {
        var car= await GetOneByIdAsync(id, false);
        if(car == null) 
            throw new ArgumentNullException(nameof(car));
        else
            Remove(car);

    }

    public void Update(Car car)=>Edit(car);
    
}
