using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts.DTO;

namespace WebUi.Models
{
    public class WendingMachineViewModel
    {
        public int id { get; set; }
        public decimal Balance { get; set; }
        public List<DrinkDto> Drinks { get; set; }
        public string ImageUrl { get; set; }
    }
}
