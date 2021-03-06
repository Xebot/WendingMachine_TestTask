﻿using System;
using System.Collections.Generic;
using System.Text;
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces.Base;

namespace WendingDomain.RepositoryInterfaces
{
    public interface ICoinStorageRepository : IRepositoryBase<CoinStorage, int>
    {
        CoinStorage GetAllCoins();
        Coin GetCoin(decimal value);
    }
    
}
