using ADV2;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static List<Product> catalog = new()
    {
        new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
        new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
        new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
        new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
        new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
        new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
        new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
        new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
        new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
        new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }


    };
    #region Delegate as param
    /*
    public delegate bool FilterDelegate(int number);
    public delegate int TransformDelegate(int number);

    internal class NumberProcessor
    {
        public static List<int> Filter(List<int> numbers, FilterDelegate filter)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                if (filter(number))
                {
                    result.Add(number);
                }
            }
            return result;
        }
        public static List<int> Transform(List<int> numbers, TransformDelegate transform)
        {
            List<int> result = new();
            foreach (int number in numbers)
            {
                result.Add(transform(number));
            }

            return result;
        }
        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
        public static bool IsOdd(int n)
        {
            return n % 2 != 0;
        }
        public static bool IsGreaterThan10(int n)
        {
            return n > 10;
        }

        public static int Double(int n)
        {
            return 2 * n;
        }
        public static int Square(int n)
        {
            return n * n;
        }

    }
    */
    #endregion

    #region Multicast Delegates

    delegate void NotificationDelegate(string message);

    internal class NotificationService
    {
        public static void SendEmail(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
        public static void SendSMS(string message)
        {
            Console.WriteLine($"SMS: {message}");
        }
        public static void SendPush(string message)
        {
            Console.WriteLine($"Push: {message}");
        }
        public static void LogToConsole(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }



    #endregion


    #region Task01


    static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
    {
        List<Product> Result = new();
        foreach (Product product in products)
        {
            if (filter(product))
            {
                Result.Add(product);
            }
        }
        return Result;
    }

    #endregion

    #region Task 2.1

    public static void PrintReport(List<Product> products, Action<Product> action)
    {
        foreach (Product product in products)
        {
            action(product);
        }
    }


    #endregion



    static void Main(string[] args)
    {
        #region Task01

        var Electronics = SearchProducts(catalog, p => p.Category == "Electronics");
        Helper.PrintList("-- Electronics --\n", Electronics);

        var CheapProducts = SearchProducts(catalog, p => p.Price < 50);
        Helper.PrintList("\n-- Under 50$ --\n", CheapProducts);

        var InStock = SearchProducts(catalog, p => p.Stock > 0);
        Helper.PrintList("\n-- InStock --\n", InStock);

        var CheapClothing = SearchProducts(catalog, p => p.Price < 100 && p.Category == "Clothing");
        Helper.PrintList("\n-- Clothes under 100$ --\n", CheapClothing);

        #endregion


        #region Task 2.1

        Console.WriteLine("\n--- Short Report ---\n");

        PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));


        Console.WriteLine("\n--- Detailed Report ---\n");

        PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));



        #endregion

    }
}