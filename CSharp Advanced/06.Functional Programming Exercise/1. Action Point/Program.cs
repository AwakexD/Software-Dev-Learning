using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = (x) => Console.WriteLine(x);
            List<string> names = Console.ReadLine().Split().ToList();

            names.ForEach(print);
        }
    }
}
