using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> isLess = (name, length) => name.Length <= length;

            Action<List<string>> printer = (list) =>
            {
                Console.WriteLine(string.Join('\n', names.Where(x => isLess(x, lenght))));
            };

            printer(names);
        }
    }
}
