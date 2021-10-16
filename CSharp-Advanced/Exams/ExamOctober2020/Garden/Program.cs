using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[,] garden = new int[gardenSize[0], gardenSize[1]];

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                int[] positionOfFlower = command.Split(' ').Select(int.Parse).ToArray();
                int flowerRow = positionOfFlower[0];
                int flowerCol = positionOfFlower[1];

                if (!IsInside(garden, flowerRow, flowerCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    garden[flowerRow, flowerCol]++;

                    for (int row = 0; row < garden.GetLength(0); row++)
                    {
                        if (flowerRow != row)
                        {
                            garden[row, flowerCol]++;
                        }
                    }

                    for (int col = 0; col < garden.GetLength(1); col++)
                    {
                        if (flowerCol != col)
                        {
                            garden[flowerRow, col]++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            PrintMatrix(garden);
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                    if (col != matrix.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
