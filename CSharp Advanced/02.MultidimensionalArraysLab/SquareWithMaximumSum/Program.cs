using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int row = rowsAndCols[0];
            int col = rowsAndCols[1];   

            int[,] matrix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int k = 0; k < col; k++)
                {
                    matrix[i, k] = input[k];
                }
            }

            int maxSum = 0;
            int maxRowIndex = 0;
            int maxColIndex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i + 1 < row && j + 1 < col)
                    {
                        int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                        if (sum >= maxSum)
                        {
                            maxSum = sum;
                            maxColIndex = j;
                            maxRowIndex = i;
                        }
                    }
                }
            }

            Print(matrix, maxRowIndex, maxColIndex, maxSum);
            
        }
        static void Print(int[,] matrix ,int RowIndex, int ColIndex, int Sum)
        {
            for (int row = RowIndex; row < RowIndex + 2; row++)
            {
                for (int col = ColIndex; col < ColIndex + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(Sum);
        }
    }
}
