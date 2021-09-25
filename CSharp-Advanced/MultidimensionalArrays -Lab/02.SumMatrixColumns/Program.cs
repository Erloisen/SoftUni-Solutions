using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = ReadArrayFromConsole();

            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentLine = ReadArrayFromConsole();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sumCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumCol += matrix[row, col];
                }

                Console.WriteLine(sumCol);
            }
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
