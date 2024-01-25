using System;
using System.Linq;

namespace _2._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string> print = n => Console.WriteLine("Sir " + n);

            Array.ForEach(names ,print);
        }
    }
}
