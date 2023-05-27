﻿namespace Pizzeria.Business.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }

        public Pizza Pizza { get; set; }

        public IEnumerable<Topping> ExtraToppings { get; set; }

        public decimal TotalCost => Pizza.BasePrice + ExtraToppings.Sum(t => t.Price);
    }
}