using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Interface;
using PizzaStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaStore.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly IPizzaRepository _pizzaService;

        public HomeController(IPizzaRepository service)
        {
            _pizzaService = service;
        }
        // GET: /<controller>/
        [HttpGet]
        public  IActionResult Index()
        {
            IEnumerable<Pizza> pizzas = _pizzaService.GetAll();
            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> GetPizza(long id)
        {
            var pizza = _pizzaService.GetPizza(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [Route("pizzabyname")]
        [HttpGet]
        public ActionResult<Pizza> GetPizzaByName(string name)
        {
            IEnumerable<Pizza> pizzas = _pizzaService.GetAllPizzaByName(name);

            if(pizzas == null)
            {
                return NotFound();
            }

            return Ok(pizzas);
        }

        [HttpPost]
        public ActionResult<Pizza> AddNewPizzaCreate(Pizza pizza)
        {
            _pizzaService.AddNewPizza(pizza);
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id, pizza });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(long id, Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }
            _pizzaService.Update(pizza);
            return Ok();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {

            _pizzaService.Remove(id);
            return NoContent();
        }


    }
}

