using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(size);

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "END")
                {
                    Print(matrix);
                    break;
                }

                if (command[0] == "Add") //Add 0 0 5
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int number = int.Parse(command[3]);

                    try
                    {
                        matrix[row, col] += number;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (command[0] == "Subtract") //Subtract 1 1 2
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int number = int.Parse(command[3]);

                    try
                    {
                        matrix[row, col] -= number;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

        }
        static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] ReadMatrix(int size)
        {
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }
    }
}
