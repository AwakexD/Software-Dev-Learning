using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Stack<char> stack = new Stack<char>(str);

            while(stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
