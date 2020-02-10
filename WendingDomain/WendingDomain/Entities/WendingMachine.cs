using System.Collections.Generic;

namespace WendingDomain.Entities
{
    /// <summary>
    /// Описание самого аппарата
    /// </summary>
    public class WendingMachine : EntityBase<int>
    {
        public WendingMachine()
        {
            this.Drinks = new List<Drink>();
        }
        /// <summary>
        /// Текущий баланс в автомате
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Состояние репозитория напитков
        /// </summary>
        public virtual List<Drink> Drinks { get; set; }
    }
}
