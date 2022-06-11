using System;
using PizzaStore.Models;

namespace PizzaStore.Interface
{
    public interface IDataRepository
    {
        IEnumerable<Pizza> GetAll();
    }
}

