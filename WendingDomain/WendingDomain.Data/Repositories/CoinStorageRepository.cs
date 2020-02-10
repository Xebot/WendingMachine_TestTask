using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WendingDomain.Data.Repositories.Base;
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces;
using WendingDomain.RepositoryInterfaces.Base;

namespace WendingDomain.Data.Repositories
{
    public class CoinStorageRepository : BaseRepository<CoinStorage, int>, ICoinStorageRepository
    {
        public CoinStorageRepository(WendingDbContext _dbContext) : base(_dbContext)
        {
            
        }
        
        public CoinStorage GetAllCoins()
        {
            
            var storage = _dbContext.Storage.Include(z => z.Coins).FirstOrDefault();
            return storage;
        }

        public Coin GetCoin(decimal value)
        {
            var storage = _dbContext.Storage.Include(z => z.Coins).FirstOrDefault();
            var coin = storage.Coins.FirstOrDefault(x => x.Value == value);
            return coin;
        }

    }
}
