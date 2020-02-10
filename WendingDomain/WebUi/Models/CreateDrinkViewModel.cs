using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.Models
{
    public class CreateDrinkViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public bool isAvailable { get; set; }
        public string ImageUrl { get; set; }
    }
}
