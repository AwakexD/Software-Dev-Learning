using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int marioHealth = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] field = new char[numberOfRows][];
            int marioRow = default;
            int marioCol = default;

            InitFiled(ref field, ref numberOfRows, ref marioRow, ref marioCol);

            ExecuteCommands(ref field, ref marioHealth, ref marioRow, ref marioCol);

            Print(field);
        }
        static void InitFiled(ref char[][] field, ref int numberOfRows, ref int marioRow, ref int marioCol)
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                char[] currentLine = Console.ReadLine().ToCharArray();
                field[row] = currentLine;

                if (currentLine.Contains('M'))
                {
                    marioRow = row;
                    marioCol = currentLine.ToList().IndexOf('M');
                }
            }
        }

        static void ExecuteCommands(ref char[][] field, ref int marioHealth, ref int marioRow, ref int marioCol)
        {
            while(true)
            {
                string[] data = Console.ReadLine().Split();

                string direction = data[0];
                int enemyRow = int.Parse(data[1]);
                int enemyCol = int.Parse(data[2]);

                field[enemyRow][enemyCol] = 'B'; //Spawning enemy
                marioHealth--;

                field[marioRow][marioCol] = '-';

                if (direction == "W" && marioRow - 1 >= 0)
                {
                    marioRow--;
                }
                else if (direction == "S" && marioRow + 1 < field.GetLength(0))
                {
                    marioRow++;
                }
                else if (direction == "A" && marioCol - 1 >= 0)
                {
                    marioCol--;
                }
                else if (direction == "D" && marioCol + 1 < field[marioRow].Length)
                {
                    marioCol++;
                }

                if (field[marioRow][marioCol] == 'B')
                {
                    marioHealth -= 2;
                }
                else if (field[marioRow][marioCol] == 'P')
                {
                    field[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioHealth}");
                    break;
                }

                if (marioHealth <= 0)
                {
                    field[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                field[marioRow][marioCol] = 'M';
            }

        }

        static void Print(char[][] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.WriteLine(new String(field[i]));
            }
        }
    }
}
