using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.DTO;

namespace Wending.Api.Controllers
{
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        protected readonly IDrinkService _drinkService;
        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            IList<DrinkDto> drinks = _drinkService.GetAll();
            return Ok(drinks);

        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
