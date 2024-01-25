using System;
using System.Linq;
using System.Collections.Generic;

namespace TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int count = 0;

            string str = Console.ReadLine();
            while (str != "end")
            {
                if (str == "green")
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        count++;
                    }
                }
                else
                {
                    queue.Enqueue(str);
                }

                str = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
