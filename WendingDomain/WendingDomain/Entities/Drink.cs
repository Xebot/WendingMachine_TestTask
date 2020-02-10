using System;
using System.Collections.Generic;
using System.Text;

namespace WendingDomain.Entities
{
    /// <summary>
    /// Напиток
    /// </summary>
    public class Drink : EntityBase<int>
    {
        ///<summary>
        /// Название напитка
        /// </summary>
        public string Title { get; set; }

        ///<summary>
        /// Цена напитка
        /// </summary>
        public decimal Price { get; set; }

        ///<summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }

        ///<summary>
        /// Доступен ли напиток
        /// </summary>
        public bool isAvailable { get; set; }
        /// <summary>
        /// Путь к изображению напитка
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// В каком вендинговом аппарате находится напиток (если будет несколько аппаратов в будущем)
        /// </summary>
        public virtual WendingMachine WendingMachine { get; set; }
    }
}
