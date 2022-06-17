using System;
using PizzaStore.Models;

namespace PizzaStore.Interface
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAll();
        IEnumerable<Pizza> GetAllOrders();
        Pizza GetPizza(long id);
        Pizza AddNewPizza(Pizza pizza);
        void Remove(int id);
        bool Update(Pizza pizza);
        IEnumerable<Pizza> GetAllPizzaByName(string name);
    }
}

