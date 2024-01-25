using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isUpper = x => Char.IsUpper(x[0]);

            Console.WriteLine(String.Join('\n', words.Where(isUpper)));
        }
    }
}
