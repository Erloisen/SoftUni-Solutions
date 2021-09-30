using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            Queue<char> snake = new Queue<char>(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        SnakeMoves(matrix, snake, row, col);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        SnakeMoves(matrix, snake, row, col);
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void SnakeMoves(char[,] matrix, Queue<char> snake, int row, int col)
        {
            char element = snake.Dequeue();
            matrix[row, col] = element;
            snake.Enqueue(element);
        }
    }
}
