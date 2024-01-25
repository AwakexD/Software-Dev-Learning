using System;
using System.Linq;
using System.Collections.Generic;

namespace StackSm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            string[] command = Console.ReadLine().Split(' ');
            while (command[0].ToLower() != "end")
            {
                if (command[0].ToLower() == "add")
                {
                    int num1 = int.Parse(command[1]);
                    int num2 = int.Parse(command[2]);

                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if (command[0].ToLower() == "remove")
                {
                    int count = int.Parse(command[1]);

                    if (count <= stack.Count())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().Split(' ');
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
