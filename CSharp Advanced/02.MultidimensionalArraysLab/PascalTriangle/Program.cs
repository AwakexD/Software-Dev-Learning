using System;
using System.Linq;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long size = long.Parse(Console.ReadLine());
            long[][] triangle = new long[size][];
            triangle[0] = new long[1] { 1 };

            for (long row = 1; row < size; row++)
            {
                triangle[row] = new long[triangle[row - 1].Length + 1];
                for (long col = 0; col < triangle[row].Length; col++)
                {
                    if (triangle[row - 1].Length > col)
                    {
                        triangle[row][col] += triangle[row - 1][col];
                    }
                    if (col > 0)
                    {
                        triangle[row][col] += triangle[row - 1][col - 1];
                    }
                }
            }

            Prlong(triangle);
        }
        static void Prlong(long[][] jagged)
        {
            for (long row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(String.Join(" ", jagged[row]));
            }
        }   

    }
}
