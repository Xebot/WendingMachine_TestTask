using WebApi.Contracts.DTO.Base;

namespace WebApi.Contracts.DTO
{
    public class CoinDto : EntityDto<int>
    {
        /// <summary>
        /// Номинал монеты
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Доступна ли монета?
        /// </summary>
        public bool isAvailable { get; set; }

        /// <summary>
        /// Изображение монетки
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
