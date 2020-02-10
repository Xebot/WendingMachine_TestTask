using AppServices.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Contracts.DTO;
using WendingDomain.Entities;
using WendingDomain.RepositoryInterfaces;

namespace AppServices.Services
{
    public class WendingMachineService : IWendingMachineService
    {
        private readonly IWendingMachineRepository _wendingMachineRepository;
        private readonly IDrinksRepository _drinksRepository;
        private readonly IDrinkService _drinkService;
        private readonly IHelpService _helpService;
        public WendingMachineService(IWendingMachineRepository wendingMachineRepository, IDrinksRepository drinksRepository, IDrinkService drinkService, IHelpService helpService)
        {
            _wendingMachineRepository = wendingMachineRepository;
            _drinksRepository = drinksRepository;
            _drinkService = drinkService;
            _helpService = helpService;
        }
        public void AddDrinkToMachine(int machineId, int drinkId, int count)
        {                
           _drinkService.AddDrink(machineId, drinkId, count);                        
        }
        public void CreateDrink(int machineId, DrinkDto newDrink)
        {
            _drinkService.CreateDrink(machineId, newDrink);
        }
        public List<DrinkDto> GetAvailableDrink(int machineId)
        {
            var machine = _wendingMachineRepository.GetMachineByBalance(machineId);            
            return machine.Drinks.Select(Mapper.Map<DrinkDto>).Where(x => x.isAvailable == true && x.Count>0).ToList();            
        }
        public List<DrinkDto> GetAllDrinks(int machineId)
        {
            var machine = _wendingMachineRepository.GetMachineBy();
            return machine.Drinks.Select(Mapper.Map<DrinkDto>).ToList();            
        }
        public WendingMachineDto GetMachineByBalance(decimal balance)
        {
            WendingMachine machine = _wendingMachineRepository.GetMachineByBalance(balance);

            return Mapper.Map<WendingMachineDto>(machine);
        }
        public WendingMachineDto GetMachineBy()
        {
            WendingMachine machine = _wendingMachineRepository.GetMachineBy();

            return Mapper.Map<WendingMachineDto>(machine);
        }
        public WendingMachineDto GetMachineById(int machineId)
        {
            WendingMachine machine = _wendingMachineRepository.GetMachineById(machineId);

            return Mapper.Map<WendingMachineDto>(machine);
        }
        public void OrderDrink( int drinkId)
        {
            var machine = _wendingMachineRepository.GetMachineBy();
            var drink = machine.Drinks.FirstOrDefault(x => x.Id == drinkId);
            if (drink.Count > 0 && machine.Balance >= drink.Price)
            {
                drink.Count--;
                machine.Balance -= drink.Price;
                _wendingMachineRepository.Update(machine);
            }
            else
            {
                throw new ArgumentNullException($"Count of drink {drink.Title} less than 1");
            }
        }
        public decimal AddBalance(decimal Cash)
        {
            
            if (Cash > 0)
            {
                var machine = _wendingMachineRepository.GetMachineBy();
                machine.Balance += Cash;
                _wendingMachineRepository.Update(machine);
                
            }
            return _wendingMachineRepository.GetMachineBy().Balance;
        }
        public decimal SubBalance(decimal Cash)
        {
            var machine = _wendingMachineRepository.GetMachineBy();
            if (machine.Balance >= Cash)
            {
                machine.Balance -= Cash;
                _wendingMachineRepository.Update(machine);
                return machine.Balance;
            }
            else
            {
                return machine.Balance;
            }
        }
        public void MakeNotAvailableDrink(int id)
        {
            _wendingMachineRepository.GetDrink(id).isAvailable = false;
            _wendingMachineRepository.Update(_wendingMachineRepository.GetMachineBy());
            
        }
        public void MakeAvailableDrink(int id)
        {
            _wendingMachineRepository.GetDrink(id).isAvailable = true;
            _wendingMachineRepository.Update(_wendingMachineRepository.GetMachineBy());
        }
        public void TakeTips()
        {
            var machine = _wendingMachineRepository.GetMachineBy();
            machine.Balance = 0;
            _wendingMachineRepository.Update(machine);
        }
    }
}
