﻿using System;
using PizzaStore.Data;
using PizzaStore.Interface;
using PizzaStore.Models;

namespace PizzaStore.Service
{
    public class PizzaService : IPizzaRepository
	{
        private readonly PizzaDb _context;

        public PizzaService(PizzaDb context)
		{
            _context = context;
        }

        public Pizza AddNewPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChangesAsync();
            return pizza;
        }

        public IEnumerable<Pizza> GetAll()
        {         
            List<Pizza> pizzas = _context.Pizzas.ToList();
            return pizzas;
        }

        public IEnumerable<Pizza> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizza> GetAllPizzaByName(string name)
        {
            List<Pizza> pizzas = _context.Pizzas.Where(c => c.Name.Equals(name)).ToList();
            return pizzas;
        }

        public Pizza GetPizza(long id)
        {
            Pizza pizza = _context.Pizzas.Where(c => c.Id == id).FirstOrDefault();
            return pizza;
        }

        public void Remove(int id)
        {
            //var pizza = _context.Pizzas.FindAsync(id);
            //_context.Pizzas.Remove(pizza);
            //_context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public bool Update(Pizza pizza)
        {
            throw new NotImplementedException();
        }
    }
}

