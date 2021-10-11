using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;

            for (int i = 0; i < n; i++)
            {
                string lines = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    territory[i, j] = lines[j];

                    if (territory[i, j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                        territory[beeRow, beeCol] = '.';
                    }
                }
            }

            string command = Console.ReadLine();
            int pollinatedFlowers = 0;
            bool getLost = false;

            while (command != "End")
            {
                switch (command)
                {
                    case "up":
                        beeRow -= 1;
                        break;
                    case "down":
                        beeRow += 1;
                        break;
                    case "left":
                        beeCol -= 1;
                        break;
                    case "right":
                        beeCol += 1;
                        break;
                }

                if (IsInside(territory, beeRow, beeCol))
                {
                    if (territory[beeRow, beeCol] == 'f')
                    {
                        pollinatedFlowers++;
                        territory[beeRow, beeCol] = '.';
                    }
                    else if (territory[beeRow, beeCol] == 'O')
                    {
                        territory[beeRow, beeCol] = '.';
                        continue;
                    }
                }
                else
                {
                    getLost = true;
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                command = Console.ReadLine();
            }

            if (pollinatedFlowers < 5)
            {
                int neededFlowers = 5 - pollinatedFlowers;
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {neededFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            if (!getLost)
            {
                territory[beeRow, beeCol] = 'B';
            }

            PrintMatrix(territory);
        }

        public static bool IsInside(char[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1));
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
