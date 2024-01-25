using System;
using System.Linq;
using System.Collections.Generic;

namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int counter = int.Parse(Console.ReadLine());
            Queue<string> childrens = new Queue<string>(input);

            while (childrens.Count > 1)
            {
                for (int i = 0; i < counter - 1; i++)
                {
                    childrens.Enqueue(childrens.Dequeue());
                }
                Console.WriteLine($"Removed {childrens.Dequeue()}");
            }

            Console.WriteLine($"Last is {childrens.Peek()}");
        
        }
    }
}
