using System;
using System.Collections.Generic;
using System.Text;
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces.Base;

namespace WendingDomain.RepositoryInterfaces
{
    public interface IWendingMachineRepository : IRepositoryBase<WendingMachine, int>
    {
        WendingMachine GetMachineById(int machineId);
        WendingMachine GetMachineByBalance(decimal balance);
        WendingMachine GetMachineBy();
        List<Drink> GetAvailableDrinks(int machineId);
        Drink GetDrink(int drinkId);
        Decimal GetBalance(int machineId);
        Decimal AddCash(int machineId, decimal Cash);
        Decimal SubCash(int machineId, decimal Cash);
    }
}
