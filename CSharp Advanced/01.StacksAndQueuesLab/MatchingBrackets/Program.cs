using System;
using System.Linq;
using System.Collections.Generic;

namespace MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string str = Console.ReadLine();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    stack.Push(i);
                }
                else if (str[i] == ')')
                {
                    int start = stack.Pop();
                    int end = i;
                    Console.WriteLine(str.Substring(start, end - start + 1));
                }
            }
        }
    }
}
