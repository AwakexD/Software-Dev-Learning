using System;
using System.Linq;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string str = Console.ReadLine();

            while (str != "End")
            {
                if (str != "Paid")
                {
                    queue.Enqueue(str);
                }
                else
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue()); 
                    }
                }
                str = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
