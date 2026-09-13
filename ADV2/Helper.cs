using System;
using System.Collections.Generic;
using System.Text;

namespace ADV2
{
    internal class Helper
    {

        public static void PrintList(string listName, List<Product> products)
        {
            Console.WriteLine(listName);
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Name} - ${product.Price} (Stock: {product.Stock})");
            }
        }


        public static void PrintList2(List<Product> products)
        {
            Console.WriteLine("\n--- Low-Stock ALert ---\n");
            foreach (Product product in products)
            {
                Console.WriteLine($"[LOW STOCK] {product.Name}: only {product.Stock} left!");
            }
        }

    }
}