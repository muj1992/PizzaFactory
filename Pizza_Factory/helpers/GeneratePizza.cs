using Pizza_Factory.model;
using System;
using System.Collections.Generic;
using System.Text;
using Pizza_Factory.enums; 

namespace Pizza_Factory.helpers
{
    public class GeneratePizza : IGeneratePizza
    {
        public List<Pizza> GeneratePizzas(int numberOfPizzas)
        {
            var listOfPizzas = new List<Pizza>(); 
            
            for (int i = 0; i < numberOfPizzas; i++)
            {
                var pizza = new Pizza()
                {
                    isCooked = false,
                    @base = GenerateRandomBase(),
                    topping = GenerateRandomTopping()
                };

                listOfPizzas.Add(pizza);

            }

            return listOfPizzas;
        }

        private PizzaBase GenerateRandomBase()
        {
            var rnd = new Random();
            return (PizzaBase)rnd.Next(Enum.GetNames(typeof(PizzaBase)).Length); 
        }

        private Toppings GenerateRandomTopping()
        {
            var rnd = new Random();
            return  (Toppings)rnd.Next(Enum.GetNames(typeof(Toppings)).Length);

        }

   
    }
}
