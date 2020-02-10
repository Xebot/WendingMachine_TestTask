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
    public class DrinkService : IDrinkService
    {

        protected readonly IDrinksRepository _drinkRepository;
        protected readonly IWendingMachineRepository _wendingMachineRepository;

        public DrinkService(IDrinksRepository drinkRepository, IWendingMachineRepository wendingMachineRepository)
        {
            _drinkRepository = drinkRepository;
            _wendingMachineRepository = wendingMachineRepository;
        }

        public void CreateDrink(int machineId,DrinkDto drinkDto)
        {
            var machine = _wendingMachineRepository.GetMachineBy();
                
            machine.Drinks.Add(Mapper.Map<Drink>(drinkDto));
            _wendingMachineRepository.Update(machine);
        }

        public void DeleteDrink(DrinkDto drinkDto)
        {
            _drinkRepository.Delete(drinkDto.Id);
        }

        public void DeleteDrink(int drinkDtoId)
        {
            _drinkRepository.Delete(drinkDtoId);
        }

        public IList<DrinkDto> GetAll()
        {
            var drinks = _drinkRepository.GetAll().ToList();
            var result = Mapper.Map<IList<DrinkDto>>(drinks);
            return result;
        }

        public DrinkDto GetDrinkById(int drinkId)
        {
            Drink _drink = _drinkRepository.Get(drinkId);
            if (_drink == null)
            {
                throw new ArgumentNullException($"Не найден напиток с Id = {drinkId}");
            }
            var result = new DrinkDto
            {
                Id = _drink.Id,
                Title = _drink.Title,
                Price = _drink.Price
            };
            return result;
        }

        public int AddDrink(int machineId, int drinkId, int count)
        {
            var machine = _wendingMachineRepository.GetMachineById(machineId);            
            var new1 = machine.Drinks.FirstOrDefault(x => x.Id == drinkId).Count += count;
            _wendingMachineRepository.Update(machine);
            return machine.Drinks.FirstOrDefault(x => x.Id == drinkId).Count;
        }

       
    }
}
