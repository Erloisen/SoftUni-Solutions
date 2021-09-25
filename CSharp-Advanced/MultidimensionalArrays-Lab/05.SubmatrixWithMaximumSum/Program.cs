using System;
using System.Linq;

namespace _05.SubmatrixWithMaximumSum
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

            int[] subMatrixSizes = ReadMatrixFromConsole();
            int subRows = subMatrixSizes[0];
            int subCols = subMatrixSizes[1];

            long maxSum = long.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - subRows + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - subCols + 1; col++)
                {
                    int sum = 0;
                    for (int i = 0; i < subRows; i++)
                    {
                        for (int j = 0; j < subCols; j++)
                        {
                            sum += matrix[row + i, col + j];
                        }
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            for (int row = maxSumRow; row < maxSumRow + subRows; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + subCols; col++)
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
