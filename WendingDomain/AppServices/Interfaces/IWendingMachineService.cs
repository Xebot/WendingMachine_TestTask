using System.Collections.Generic;
using WebApi.Contracts.DTO;

namespace AppServices.Interfaces
{
    public interface IWendingMachineService
    {
        WendingMachineDto GetMachineById(int machineId);
        WendingMachineDto GetMachineByBalance(decimal balance);
        WendingMachineDto GetMachineBy();
        List<DrinkDto> GetAvailableDrink(int machineId);
        List<DrinkDto> GetAllDrinks(int machineId);
        void OrderDrink(int drinkId);
        decimal AddBalance(decimal add);
        decimal SubBalance(decimal sub);
        void AddDrinkToMachine(int machineId, int drinkId, int count);
        void CreateDrink(int machineId, DrinkDto drink);

        void MakeNotAvailableDrink(int id);
        void MakeAvailableDrink(int id);
        void TakeTips();

    }
}
