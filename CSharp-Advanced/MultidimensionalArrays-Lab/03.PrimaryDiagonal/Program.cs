using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquareMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfSquareMatrix, sizeOfSquareMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            int sumDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row; col <= row; col++)
                {
                    sumDiagonal += matrix[row, col];
                }
            }

            Console.WriteLine(sumDiagonal);
        }
    }
}
