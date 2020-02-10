using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WendingDomain.Data.Repositories.Base;
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces;

namespace WendingDomain.Data.Repositories
{
    public class WendingMachineRepository : BaseRepository<WendingMachine, int>, IWendingMachineRepository
    {
        public WendingMachineRepository(WendingDbContext _dbContext) : base(_dbContext)
        {

        }

        public WendingMachine GetMachineById(int machineId)
        {
            var machine = _dbContext.WendingMachine.Include(z => z.Drinks).FirstOrDefault(x => x.Id == machineId);
            return machine;
        }
        public WendingMachine GetMachineByBalance(decimal balance)
        {
            
            var machine = _dbContext.WendingMachine.Include(z => z.Drinks).FirstOrDefault(x => x.Balance == balance);
            
            return machine;
        }
        public WendingMachine GetMachineBy()
        {
            var machine1 = _dbContext.WendingMachine.Include(z => z.Drinks).FirstOrDefault();
            return machine1;
        }
        public decimal AddCash(int machineId, decimal Cash)
        {
            var machine = GetMachineById(machineId);
            machine.Balance = machine.Balance + Cash;
            _dbContext.WendingMachine.Update(machine);
            return machine.Balance;
        }

        public List<Drink> GetAvailableDrinks(int machineId)
        {
            var machine = GetMachineById(machineId);
            return machine.Drinks;
        }

        public decimal GetBalance(int machineId)
        {
            var machine = GetMachineById(machineId);
            return machine.Balance;
        }

        public Drink GetDrink(int drinkId)
        {
            var machine = GetMachineBy();
            var drink = machine.Drinks.FirstOrDefault(x => x.Id == drinkId);
            return drink;
        }

        public decimal SubCash(int machineId, decimal Cash)
        {
            var machine = GetMachineById(machineId);
            if (machine.Balance >= Cash)
            {
                machine.Balance -= Cash;
                _dbContext.WendingMachine.Update(machine);
                return machine.Balance;
            }
            else
            {
                throw new InvalidOperationException();
            }
            
        }
    }
}
