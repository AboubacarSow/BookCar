using BookCar.Application.Interfaces.Repositories;
using BookCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookCar.Infrastructure.Data.Repositories;

public class AboutRepository : RepositoryBase<About>, IAboutRepository
{
    public AboutRepository(BookCarDbContext context) : base(context)
    {
    }

    public void Create(About about)=> base.Add(about);
    

    public async Task<IEnumerable<About>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<About> GetOneByIdAsync(int id, bool trackChanges)
    { 
        return  await FindByCondition(a=>a.Id==id, trackChanges).FirstOrDefaultAsync();
       
    }

    public async Task RemoveByIdAsync(int id)
    {
        var model= await GetOneByIdAsync(id, false);
        if (model == null)
        {
            throw new ArgumentException("Item does not found");
        }
        else
        {
            Remove(model);
        }
        
    }
    public void Update(About about)=>Edit(about);
   
}
