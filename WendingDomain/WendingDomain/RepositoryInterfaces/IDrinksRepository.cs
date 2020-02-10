
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces.Base;

namespace WendingDomain.RepositoryInterfaces
{
    public interface IDrinksRepository : IRepositoryBase<Drink, int>
    {
        Drink Get(int Id);
    }
}
