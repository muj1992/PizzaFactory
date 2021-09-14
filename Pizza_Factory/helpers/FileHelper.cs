using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Pizza_Factory.model;

namespace Pizza_Factory.helpers
{
    public class FileHelper
    {
        private string pathString = @"c:\PizzaFactory\";
        public void CreateDirectory(string fileName)
        {

            Directory.CreateDirectory(pathString);

            pathString = Path.Combine(pathString, fileName);

            if (!File.Exists(pathString))
            {
                using (FileStream fs =  File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                       fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
            }

        }

        public async Task WriteToFile(Pizza pizza)
        {
            string[] text = { "Pizza Base: ", pizza.@base.ToString(), 
                                "Toppings: ", pizza.topping.ToString() };

            await File.AppendAllLinesAsync(pathString, text); 


        }



    }
}
