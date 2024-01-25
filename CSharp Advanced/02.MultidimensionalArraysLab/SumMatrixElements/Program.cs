using System;
using System.Linq;
using System.Collections.Generic;

namespace SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCol = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int sum = 0;
            int[, ] matrix = new int [rowsAndCol[0], rowsAndCol[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                    sum += rowInput[j];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
