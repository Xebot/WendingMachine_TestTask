using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts.DTO;

namespace WebUi.Models
{
    public class CoinStorageViewModel
    {
        public List<CoinDto> Coins { get; set; }
    }
}
