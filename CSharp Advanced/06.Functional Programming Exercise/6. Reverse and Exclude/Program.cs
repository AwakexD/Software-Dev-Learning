using System;
using System.Linq;
using System.Collections.Generic;

namespace _6._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse)
                .Reverse().ToList();

            int specialNumber = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = x => x % specialNumber == 0;

            Action<List<int>> removeElements = x => x.RemoveAll(x => isDivisible(x));
            Action<List<int>> print = x => Console.WriteLine(String.Join(" ", x));

            removeElements(numbers);
            print(numbers);
            
        }
    }
}
