using System;
using System.Linq;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, decimal> parser = x => decimal.Parse(x);
            Func<decimal, decimal> addVat = x => AddVAT(x);

            decimal[] prices = Console.ReadLine().Split(", ").Select(parser).Select(addVat).ToArray();

            Console.WriteLine(string.Join("\n", prices));
        }
        static decimal AddVAT (decimal price)
        {
            return Math.Round(price += price * 0.2m, 2);
        }
    }
}
