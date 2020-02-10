using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Models
{
    public class DrinksViewModel
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
        
    }
}
