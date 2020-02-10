using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts.DTO;

namespace Wending.Api.Controllers
{
    [Route("api/[controller]")]
    public class WendingMachineController : ControllerBase
    {
        protected readonly IDrinkService _drinkService;
        protected readonly IWendingMachineService _wendingMachineService;
        private readonly IHelpService _helpService;
        public WendingMachineController(IDrinkService drinkService, IWendingMachineService wendingMachineService, IHelpService helpService)
        {
            _drinkService = drinkService;
            _wendingMachineService = wendingMachineService;
            _helpService = helpService;
        }

        [HttpGet]
        [Route("GetCoins")]
        public CoinStorageDto GetCoins()
        {
           return _helpService.GetAllCoins();
        }
        [HttpPost]
        [Route("MakeNotAvailableCoin/{value}")]
        public void MakeNotAvailableCoin(decimal value)
        {
            
            _helpService.MakeNotAvailableCoin(value);
        }
        [HttpPost]
        [Route("MakeAvailableCoin/{value}")]
        public void MakeAvailableCoin(decimal value)
        {

            _helpService.MakeAvailableCoin(value);
        }


        [HttpPost]
        [Route("MakeNotAvailableDrink/{id}")]
        public void MakeNotAvailableDrink(int id)
        {

            _wendingMachineService.MakeNotAvailableDrink(id);
        }
        [HttpPost]
        [Route("MakeAvailableDrink/{id}")]
        public void MakeAvailableDrink(int id)
        {

            _wendingMachineService.MakeAvailableDrink(id);
        }

        [HttpGet]
        [Route("GetMachine/{id}")]
        public WendingMachineDto GetMachine(decimal balance)
        {
            
            return _wendingMachineService.GetMachineBy();
        }
        [HttpGet]
        [Route("GetAvailableDrinks")]
        public List<DrinkDto> GetAvailableDrinks(int wendingMachineId = 1)
        {
            return _wendingMachineService.GetAvailableDrink(wendingMachineId);
        }
        [HttpPost]
        [Route("CreateDrink")]
        public List<DrinkDto> CreateDrink([FromBody] DrinkDto newDrink, int machineId=0)
        {
            
            _wendingMachineService.CreateDrink(machineId, newDrink);
            return _wendingMachineService.GetAllDrinks(machineId);
        }

        [HttpPost]
        [Route("AddDrink")]
        public void AddDrink(int machineId, int drinkId, int count)
        {
            _wendingMachineService.AddDrinkToMachine(machineId, drinkId, count);
        }

        [HttpPost]
        [Route("AddBalanceCoin/{add}")]
        public decimal AddBalanceCoin(decimal add)
        {
            if (add < 0)
            {
                throw new ArgumentNullException("Cash cant be < 0");
            }
            decimal newBalance = _wendingMachineService.AddBalance(add);
            return newBalance;
        }

        [HttpPost]
        [Route("AddBalanceAdmin/{add}")]
        public decimal AddBalance(decimal add)
        {
            if(add < 0)
            {
                throw new ArgumentNullException("Cash cant be < 0");
            }
            decimal newBalance = _wendingMachineService.AddBalance(add);
            return newBalance;
        }
        [HttpPost]
        [Route("SubBalanceAdmin/{sub}")]
        public decimal SubBalance(decimal sub)
        {
            _wendingMachineService.SubBalance(sub);
            return _wendingMachineService.GetMachineBy().Balance;
        }

        

        [HttpGet]
        [Route("Taketips")]
        public void Taketips()
        {
            _wendingMachineService.TakeTips();
        }

        [HttpPost]
        [Route("OrderDrink/{drinkId}")]
        public void OrderDrink(int drinkId)
        {
            _wendingMachineService.OrderDrink(drinkId);
        }
    }
}
