using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WendingDomain.Data.Repositories.Base;
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces;

namespace WendingDomain.Data.Repositories
{
    public class CoinRepository : BaseRepository<Coin, int>, ICoinRepository
    {
        public CoinRepository(WendingDbContext _dbContext) : base(_dbContext)
        {

        }

        
    }
}
