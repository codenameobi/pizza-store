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
        

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Pizza> employees = PizzaService.GetAll();
            return Ok(employees);
        }
    }
}

