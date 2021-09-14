using Pizza_Factory.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Factory.helpers
{
    public class CalculateTime : ICalculateTime
    {
        public double CalculateTotalTime(PizzaBase pizzaBase, Toppings topping, int baseCookingTime)
        {
            return CalculateBaseTime(pizzaBase, baseCookingTime) + CalculateToppings(topping);
        }

        private int CalculateToppings(Toppings topping)
        {
            Enum chosenTopping = topping;

            var enumLength = chosenTopping.ToString().Length; 

           return enumLength * 100;
        }   
   
        private double CalculateBaseTime(PizzaBase pizzaBase, int baseCookingTime)
        {
            var cookingTimeMultiplier = 0.0;

            switch (pizzaBase)
            {
                case PizzaBase.DeepPan:
                    cookingTimeMultiplier = 2;
                    break;
                case PizzaBase.StuffedCrust:
                    cookingTimeMultiplier = 1.5;
                    break;
                case PizzaBase.ThinAndCrusty:
                    cookingTimeMultiplier = 1;
                    break;
            }

            return cookingTimeMultiplier * baseCookingTime; 
        }
    }
}
