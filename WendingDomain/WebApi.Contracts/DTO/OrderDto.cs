
namespace WebApi.Contracts.DTO
{
    public class OrderDto
    {
        /// <summary>
        /// ID вендинговой машины (когда их будет несколько)
        /// </summary>
        public int machineId;
        /// <summary>
        /// ID напитка который заказывает клиент
        /// </summary>
        public int drinkId;
        /// <summary>
        /// Количество напитков заказанных
        /// </summary>
        public int count;
    }
}
