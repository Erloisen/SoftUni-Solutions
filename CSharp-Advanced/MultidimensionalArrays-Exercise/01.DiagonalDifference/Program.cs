using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfTheMatrix, sizeOfTheMatrix];
            int sumRightDiagonal = 0;
            int sumLeftDiagonal = 0;
            for (int row = 0; row < sizeOfTheMatrix; row++)
            {
                int[] valuesForRows = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < sizeOfTheMatrix; col++)
                {
                    matrix[row, col] = valuesForRows[col];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumRightDiagonal += matrix[i, i];
                sumLeftDiagonal += matrix[i, matrix.GetLength(1) - 1 - i];
            }

            Console.WriteLine(Math.Abs(sumRightDiagonal - sumLeftDiagonal));
        }
    }
}
