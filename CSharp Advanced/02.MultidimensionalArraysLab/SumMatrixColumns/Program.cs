using System;
using System.Linq;
using System.Collections.Generic;

namespace SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowcol = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[rowcol[0], rowcol[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = input[k];
                }
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[j, i];
                }
                Console.WriteLine(sum);
            }

        }
    }
}
