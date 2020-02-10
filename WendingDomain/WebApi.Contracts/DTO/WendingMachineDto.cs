using System.Collections.Generic;
using WebApi.Contracts.DTO.Base;

namespace WebApi.Contracts.DTO
{
    public class WendingMachineDto : EntityDto<int>
    {
        /// <summary>
        /// Текущий баланс в автомате
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Состояние репозитория напитков
        /// </summary>
        public List<DrinkDto> Drinks { get; set; }
    }
}
