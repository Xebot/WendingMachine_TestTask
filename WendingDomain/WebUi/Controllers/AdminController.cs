using AppServices.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Contracts.DTO;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWendingMachineService _wendingMachineService;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        public AdminController(IWendingMachineService wendingMachineService, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _wendingMachineService = wendingMachineService;
            _client = new HttpClient();
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<ActionResult> Index()
        {
            var url = string.Format(GetAbsolutePath("GetMachine"), 0);
            ViewBag.Coins = GetCoins().Result;
            using (var response = await _client.GetAsync(url))
            {
                WendingMachineDto machine = await response.Content.ReadAsAsync<WendingMachineDto>();
                ViewBag.Balance = machine.Balance;
                return View(Mapper.Map<WendingMachineViewModel>(machine));
            }
        }
        public async Task<IActionResult> AddBalance(decimal value, decimal balance)
        {
            var url = string.Format(GetAbsolutePath("addbalance"), value, balance);
            AddBalanceDto add = new AddBalanceDto { Cash = value, Balance = balance };
            await _client.PostAsJsonAsync(url, add);
            return RedirectToAction("Index");
        }
        public async Task<CoinStorageViewModel> GetCoins()
        {
            CoinStorageDto coins;
            var url = string.Format(GetAbsolutePath("GetCoins"), 1);
            using (var response = await _client.GetAsync(url))
            {
                coins = await response.Content.ReadAsAsync<CoinStorageDto>();
            }
            return Mapper.Map<CoinStorageViewModel>(coins);
        }
        [HttpPost]
        public async Task<ActionResult> CreateDrink(CreateDrinkViewModel newDrink, IFormFile uploadedFile, string isAvailable = null )
        {
            if (isAvailable != null) newDrink.isAvailable = true;         

            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/images/drinks/" + uploadedFile.FileName;
                // сохраняем файл в папку images в каталоге wwwroot
                using (var fileStream = new FileStream(_hostingEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                newDrink.ImageUrl = path;                
            }
            var createDrink = Mapper.Map<DrinkDto>(newDrink);
            var url = GetAbsolutePath("CreateDrink");
            await _client.PostAsJsonAsync<DrinkDto>(url, createDrink);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> MakeNotAvailableCoin (decimal value)
        {
            var url = string.Format(GetAbsolutePath("MakeNotAvailableCoin"),value);
            await _client.PostAsJsonAsync(url, value);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> MakeAvailableCoin (decimal value)
        {
            var url = string.Format(GetAbsolutePath("MakeAvailableCoin"), value);
            await _client.PostAsJsonAsync(url, value);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> MakeNotAvailableDrink(int id)
        {
            var url = string.Format(GetAbsolutePath("MakeNotAvailableDrink"), id);
            await _client.PostAsJsonAsync(url, id);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> MakeAvailableDrink(int id)
        {
            var url = string.Format(GetAbsolutePath("MakeAvailableDrink"), id);
            await _client.PostAsJsonAsync(url, id);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> SubBalanceAdmin(int Subcash)
        {
            var url = string.Format(GetAbsolutePath("SubBalanceAdmin"), Subcash);
            await _client.PostAsJsonAsync(url, Subcash);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AddBalanceAdmin(int Addcash)
        {
            var url = string.Format(GetAbsolutePath("AddBalanceAdmin"), Addcash);
            await _client.PostAsJsonAsync(url, Addcash);
            return RedirectToAction("Index");
        }
        private string GetAbsolutePath(string methodName)
        {
            return $"{_configuration["CoreServiceApi:BaseUrl"]}{_configuration[$"CoreServiceApi:Areas:WendingMachine:{methodName}"]}";
        }

        
    }
}
