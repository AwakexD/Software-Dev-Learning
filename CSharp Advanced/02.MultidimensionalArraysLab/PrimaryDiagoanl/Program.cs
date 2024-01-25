using System;
using System.Linq;
using System.Collections.Generic;

namespace PrimaryDiagoanl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            PrimaryDiagonalSum(matrix);
        }
        static void PrimaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
