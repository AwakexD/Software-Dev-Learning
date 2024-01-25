using System;
using System.Linq;
using System.Collections.Generic;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] NM = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < NM[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                set1.Add(num);
            }

            for (int k = 0; k < NM[1]; k++)
            {
                int num = int.Parse(Console.ReadLine());
                set2.Add(num);
            }

            set1.IntersectWith(set2);

            Console.WriteLine(string.Join(' ', set1));
        }
    }
}
