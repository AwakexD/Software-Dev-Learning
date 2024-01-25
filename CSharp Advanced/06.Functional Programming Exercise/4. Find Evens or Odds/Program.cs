using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string type = Console.ReadLine();

            Action<IEnumerable<int>> printer = numbers => Console.WriteLine(string.Join(" ", numbers));

            Predicate<int> predicate = null;
            
            if (type == "even")
            {
                predicate = (x) => x % 2 == 0;
            }
            else
            {
                predicate = (x) => x % 2 != 0;
            }


            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                if (predicate(i))
                {
                    numbers.Add(i);
                }   
            }

            printer(numbers);
        }
        
    }
}
