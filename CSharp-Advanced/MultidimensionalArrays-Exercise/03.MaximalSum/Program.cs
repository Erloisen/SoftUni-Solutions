using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = GetInputToArray();
            int matrixRow = input[0];
            int matrixCol = input[1];
            int[,] matrix = new int[matrixRow, matrixCol];

            for (int row = 0; row < matrixRow; row++)
            {
                int[] inputRow = GetInputToArray();
                for (int col = 0; col < matrixCol; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            long maxSum = long.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < matrixRow - 2; row++)
            {
                for (int col = 0; col < matrixCol - 2; col++)
                {
                    int currentSum = 0;
                    for (int rowOffset = 0; rowOffset <= 2; rowOffset++)
                    {
                        for (int colOffset = 0; colOffset <= 2; colOffset++)
                        {
                            currentSum += matrix[row + rowOffset, col + colOffset];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int rowOffset = 0; rowOffset <= 2; rowOffset++)
            {
                for (int colOffset = 0; colOffset <= 2; colOffset++)
                {
                    Console.Write((matrix[maxRow + rowOffset, maxCol + colOffset]) + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[] GetInputToArray()
        {
            return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
