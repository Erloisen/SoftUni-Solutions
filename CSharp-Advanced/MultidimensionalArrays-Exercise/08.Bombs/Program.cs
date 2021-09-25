using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            FillInMatrix(n, matrix);

            Queue<int> coordinates = new Queue<int>(Console.ReadLine().Split(new char[] { ',', ' ' }).Select(int.Parse).ToArray());
            while (coordinates.Count > 0)
            {
                int row = coordinates.Dequeue();
                int column = coordinates.Dequeue();

                int startRow = row - 1 < 0 ? row : row - 1;
                int endRow = row + 1 >= matrix.GetLength(0) ? row : row + 1;
                int startCol = column - 1 < 0 ? column : column - 1;
                int endCol = column + 1 >= matrix.GetLength(1) ? column : column + 1;
                
                int bomb = matrix[row, column];
                if (bomb > 0)
                {
                    BombЕxplosion(matrix, startRow, endRow, startCol, endCol, bomb);
                }
            }

            int sum = 0;
            int counter = 0;
            foreach (int element in matrix)
            {
                if (element > 0)
                {
                    sum += element;
                    counter++;
                }
            }

            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrixOnConsole(matrix);
        }

        private static void PrintMatrixOnConsole(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void BombЕxplosion(int[,] matrix, int startRow, int endRow, int startCol, int endCol, int bomb)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        matrix[i, j] -= bomb;
                    }
                }
            }
        }

        private static void FillInMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                int[] lines = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = lines[col];
                }
            }
        }
    }
}
