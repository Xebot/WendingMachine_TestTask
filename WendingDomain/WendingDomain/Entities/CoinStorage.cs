using System.Collections.Generic;

namespace WendingDomain.Entities
{
    public class CoinStorage : EntityBase<int>
    {
        public CoinStorage()
        {
            this.Coins = new List<Coin>();            
        }

        public virtual List<Coin> Coins { get; set; }
        public int CountCoins { get; set; }
    }
}
