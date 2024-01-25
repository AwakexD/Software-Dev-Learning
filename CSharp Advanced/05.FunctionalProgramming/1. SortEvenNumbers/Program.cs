using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).Where(x => x % 2 == 0).ToArray();

            // numbers = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToArray();

            Console.WriteLine(String.Join(", ", numbers.OrderBy(x => x)));
        }
    }
}
