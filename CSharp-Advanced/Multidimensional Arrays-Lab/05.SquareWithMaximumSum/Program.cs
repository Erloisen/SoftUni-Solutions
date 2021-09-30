using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = ReadMatrixFromConsole();
            int[,] matrix = new int[matrixSizes[0], matrixSizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elementsForTheMatrix = ReadMatrixFromConsole();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elementsForTheMatrix[col];
                }
            }

            long maxSum = long.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    long sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            for (int row = maxSumRow; row < maxSumRow + 2; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }

        private static int[] ReadMatrixFromConsole()
        {
            return Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        }
    }
}
