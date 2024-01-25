using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> periodicTable = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                foreach (string item in line)
                {
                    periodicTable.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }

    }
}
