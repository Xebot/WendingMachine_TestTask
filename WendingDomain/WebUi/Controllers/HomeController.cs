using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WebUi.Models;
using WebApi.Contracts.DTO;
using AutoMapper;

namespace WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWendingMachineService _wendingMachineService;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public HomeController(IWendingMachineService wendingMachineService, IConfiguration configuration)
        {
            _wendingMachineService = wendingMachineService;
            _client = new HttpClient();
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
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

        public async Task<IActionResult> AddBalanceCoin(decimal value, decimal balance)
        {
            var url = string.Format(GetAbsolutePath("AddBalanceCoin"), value);
            AddBalanceDto add = new AddBalanceDto { Cash = value, Balance = balance };
            await _client.PostAsJsonAsync(url, value);
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
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> OrderDrink (int Id)
        {
            var url = string.Format(GetAbsolutePath("orderDrink"), Id);
            await _client.PostAsJsonAsync(url, Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TakeTips()
        {
            var url = GetAbsolutePath("TakeTips");
            await _client.GetAsync(url);
            return RedirectToAction("Index");
        }

        private string GetAbsolutePath(string methodName)
        {
            return $"{_configuration["CoreServiceApi:BaseUrl"]}{_configuration[$"CoreServiceApi:Areas:WendingMachine:{methodName}"]}";
        }
    }
}
