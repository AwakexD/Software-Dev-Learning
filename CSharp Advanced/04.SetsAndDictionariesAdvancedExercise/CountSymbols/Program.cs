using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (char character in text)
            {
                if (!symbols.ContainsKey(character))
                {
                    symbols.Add(character, 0);
                }

                symbols[character]++;
            }

            foreach (KeyValuePair<char, int> item in symbols)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
