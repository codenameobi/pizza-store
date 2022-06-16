using System;
using PizzaStore.Models;

namespace PizzaStore.Interface
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAll();
        Pizza GetPizza(long id);
    }
}

