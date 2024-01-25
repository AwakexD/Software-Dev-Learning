using System;
using System.Linq;
using System.Collections.Generic;

namespace PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                {
                    queue.Enqueue(num);
                }
            }

            Console.WriteLine(String.Join(", ", queue));
        }
    }
}
