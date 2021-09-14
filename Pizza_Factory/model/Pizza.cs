using Pizza_Factory.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Factory.model
{
    public class Pizza
    {
        public PizzaBase @base { get; set; }

        public Toppings topping { get; set; }

        public bool isCooked { get; set; }

    }
}
