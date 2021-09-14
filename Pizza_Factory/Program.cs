using Microsoft.Extensions.Configuration;
using Pizza_Factory.helpers;
using Pizza_Factory.model;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pizza_Factory
{
    class Program
    {
       static async Task Main(string[] args)
       {
            var settings = BuildConfiguration(); 

            await StartCookingPizzas(settings);
       }

        static async Task StartCookingPizzas(AppSettings settings)
        {
            Console.WriteLine("Lets create some pizzas");

            var createPizzas = new GeneratePizza().GeneratePizzas(settings.NumberOfPizzas);

            Thread.Sleep(TimeSpan.FromMilliseconds(settings.CookingInterval));

            if (createPizzas.Count > 0)
            {
                var fileHelper = new FileHelper();

                fileHelper.CreateDirectory(settings.FileName);

                Console.WriteLine("Your pizzas are being prepared!");

                foreach (var pizza in createPizzas)
                {
                    if (pizza.isCooked != true && !string.IsNullOrEmpty(pizza.topping.ToString()))
                    {
                        var timeToCook = new CalculateTime().CalculateTotalTime(pizza.@base, pizza.topping, settings.BaseCookingTime);

                        await fileHelper.WriteToFile(pizza); 

                        Thread.Sleep(TimeSpan.FromMilliseconds(timeToCook));
                       
                    }
                }
                Console.WriteLine("Your Pizzas are ready! Yum!");
            }
            else
            {
                Console.WriteLine("There are no pizzas to cook!");
            }
            
        }

        public static AppSettings BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Appsettings.json");

            var config = builder.Build();

           return config.Get<AppSettings>(); 

        } 

    }
}
