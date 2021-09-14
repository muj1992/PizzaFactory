using Pizza_Factory.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Factory.helpers
{
    public interface ICalculateTime
    {
     double CalculateTotalTime(PizzaBase pizzaBase, Toppings topping, int baseCookingTime);

    }
}
