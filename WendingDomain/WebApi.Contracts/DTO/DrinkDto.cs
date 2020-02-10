using WebApi.Contracts.DTO.Base;

namespace WebApi.Contracts.DTO
{
    public class DrinkDto : EntityDto<int>
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



    }
}
