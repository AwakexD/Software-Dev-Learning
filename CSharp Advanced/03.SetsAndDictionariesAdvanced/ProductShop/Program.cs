using System;
using System.Linq;
using System.Collections.Generic;

namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List <Product>> shops = new SortedDictionary<string, List<Product>> ();
            
            string command = Console.ReadLine();
            while(command != "Revision")
            {
                string[] data = command.Split(", ");

                if (!shops.ContainsKey(data[0]))
                {
                    shops.Add(data[0], new List<Product>());
                }

                shops[data[0]].Add(new Product(data[1], double.Parse(data[2])));
                command = Console.ReadLine();
            }
            
            Revision(shops);

        }
        static void Revision(SortedDictionary<string, List<Product>> shops)
        {
            foreach (var item in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key + "->");
                foreach (Product prod in item.Value)
                {
                    Console.WriteLine($"Product: {prod.productInfo}");
                }
            }
        }
    }
    class Product
    {
        public string productName { get; set; }
        public double price { get; set; }

        public Product(string name, double price)
        {
            productName = name;
            this.price = price;
        }

        public string productInfo
        {
            get
            {
                return $"{productName}, Price: {price}";
            }
        }
    }
}
