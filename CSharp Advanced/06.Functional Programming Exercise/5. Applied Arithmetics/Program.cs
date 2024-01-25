using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<IEnumerable<int>, IEnumerable<int>> AddOne = (x) => x.Select(s => s + 1);
            Func<IEnumerable<int>, IEnumerable<int>> Multiply = (x) => x.Select(s => s * 2);
            Func<IEnumerable<int>, IEnumerable<int>> Subtract = (x) => x.Select(s => s - 1);
            Action<IEnumerable<int>> Printer = x => Console.WriteLine(String.Join(" ", x));

            string command = Console.ReadLine();
            while(command != "end")
            {
                if (command == "add")
                {
                    numbers = AddOne(numbers).ToList();
                }
                else if (command == "multiply")
                {
                    numbers = Multiply(numbers).ToList();
                }
                else if (command == "subtract")
                {
                    numbers = Subtract(numbers).ToList();
                }
                else if (command == "print")
                {
                    Printer(numbers);
                }

                command = Console.ReadLine();
            }


        }
        
    }
}
