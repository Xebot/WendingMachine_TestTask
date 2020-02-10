using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WendingDomain.Data.Repositories.Base;
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces;

namespace WendingDomain.Data.Repositories
{
    public class DrinksRepository : BaseRepository<Drink, int>, IDrinksRepository
    {
        public DrinksRepository(WendingDbContext _dbContext) : base(_dbContext)
        {

        }
        
        public Drink Get(int id)
        {
            Drink result = _dbContext.Drinks.FirstOrDefaultAsync(x => x.Id == id).Result;
            return result;
        }
        public void Delete (int Id)
        {
            var entity = Get(Id);
            _dbContext.Drinks.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
