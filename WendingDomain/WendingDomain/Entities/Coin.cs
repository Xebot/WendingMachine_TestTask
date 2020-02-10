using System;
using System.Collections.Generic;
using System.Text;

namespace WendingDomain.Entities
{
    public class Coin : EntityBase<int>
    {
        /// <summary>
        /// Номинал монеты
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Доступна ли монета
        /// </summary>
        public bool isAvailable { get; set; }

        /// <summary>
        /// Хранилище монет в котором хранится монета 
        /// (на случай, когда будет несколько аппаратов и в каждом аппарате будет свое хранилище)
        /// </summary>
        public virtual CoinStorage Storage { get; set; }

        /// <summary>
        /// Картинка монетки
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
