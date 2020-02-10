using System.Linq;
using WendingDomain.Entities;

namespace WendingDomain.RepositoryInterfaces.Base
{
    public interface IRepositoryBase<T, TId> where T : EntityWithTypedIdBase<TId>
    {
        IQueryable<T> GetAll();
        TId Create(T entity);
        TId Update(T entity);
        void Delete(TId entityId);
        
    }
}
