using System;
using System.Collections.Generic;
using System.Text;
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces.Base;

namespace WendingDomain.RepositoryInterfaces
{
    public interface ICoinRepository : IRepositoryBase<Coin, int>
    {
    }
}
