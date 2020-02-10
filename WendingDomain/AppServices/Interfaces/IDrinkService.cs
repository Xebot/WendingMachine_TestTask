using System.Collections.Generic;
using WebApi.Contracts.DTO;


namespace AppServices.Interfaces
{
    public interface IDrinkService 
    {
        DrinkDto GetDrinkById(int drinkId);
        void CreateDrink(int machineId, DrinkDto drinkDto);
        void DeleteDrink(int drinkDtoId);
        IList<DrinkDto> GetAll();
        int AddDrink(int machineId, int drinkId , int count);
    }
}
