using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces.Base;

namespace WendingDomain.Data.Repositories.Base
{
    public abstract class BaseRepository<T, TId> : IRepositoryBase<T, TId> where T : EntityBase<TId>
    {
        protected readonly WendingDbContext _dbContext;

        public BaseRepository(WendingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TId Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(TId entityId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            var result = _dbContext.Set<T>();
            return result;
        }

        public TId Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }
    }
}
