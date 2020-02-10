
namespace WebApi.Contracts.DTO
{
    public class AddBalanceDto
    {
        /// <summary>
        /// сколько добавить?
        /// </summary>
        public decimal Cash;

        /// <summary>
        /// текущий баланс аппарата
        /// </summary>
        public decimal Balance;
    }
}
