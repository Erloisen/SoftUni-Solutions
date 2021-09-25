using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = GetInputFromConsole();
            string[,] matrix = new string[int.Parse(input[0]), int.Parse(input[1])];
            FillInMatrix(matrix);

            string[] command = GetInputFromConsole();

            while (command[0] != "END")
            {
                if (command[0] != "swap" || command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);

                    if (IsValidIndex(matrix, row1, col1, row2, col2))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        Stack<string> reverse = new Stack<string>();
                        reverse.Push(matrix[row1, col1]);
                        reverse.Push(matrix[row2, col2]);

                        matrix[row1, col1] = reverse.Pop();
                        matrix[row2, col2] = reverse.Pop();

                        PrintMatrix(matrix);
                    }
                }

                command = GetInputFromConsole();
            }
        }

        private static string[] GetInputFromConsole()
        {
            return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        private static void PrintMatrix(string[,] matrix)
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

        private static bool IsValidIndex(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            if (row1 < 0 || row1 > matrix.GetLength(0) || col1 < 0 || col1 > matrix.GetLength(1) || row2 < 0 || row2 > matrix.GetLength(0) || col2 < 0 || col2 > matrix.GetLength(1))
                return true;
            else return false;
        }

        private static void FillInMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputRows = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRows[col];
                }
            }
        }
    }
}
