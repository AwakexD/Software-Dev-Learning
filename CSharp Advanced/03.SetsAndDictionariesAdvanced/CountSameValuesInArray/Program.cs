using System;
using System.Linq;
using System.Collections.Generic;


namespace CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Dictionary<double, int> occurrences = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!occurrences.ContainsKey(number))
                {
                    occurrences.Add(number, 0);
                }

                occurrences[number]++;
            }

            foreach (KeyValuePair<double, int> item in occurrences)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
