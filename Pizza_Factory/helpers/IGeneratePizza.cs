using Pizza_Factory.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Factory.helpers
{
    public interface IGeneratePizza
    {
        List<Pizza> GeneratePizzas(int numberOfPizzas);
    }
}
