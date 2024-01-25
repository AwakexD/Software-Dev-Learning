using System;
using System.Linq;

namespace SymbolinMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            
            Console.WriteLine(FindOccurrence(matrix, size, symbol));

            
        }
        static string FindOccurrence(char[,] matrix, int size, char symbol)
        {
            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (matrix[i, k] == symbol)
                    {
                        return $"({i}, {k})";
                    }
                }
            }

           return $"{symbol} does not occur in the matrix";
        }
    }
}
