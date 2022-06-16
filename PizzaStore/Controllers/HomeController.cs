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

        private readonly PizzaDb _context;

        public HomeController(PizzaDb context)
        {
            _context = context;
        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //IEnumerable<Pizza> pizzas = PizzaService.GetAll();
            return Ok(await _context.Pizzas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(long id)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(m => m.Id == id);

            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [HttpPost]
        public async Task<ActionResult<Pizza>> AddNewPizzaCreate(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
                   
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id, pizza });
        }

        [HttpPut("{id}")]
        public  async Task<IActionResult> UpdatePizza(long id, Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TodoItemExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>  DeletePizza(long id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}

