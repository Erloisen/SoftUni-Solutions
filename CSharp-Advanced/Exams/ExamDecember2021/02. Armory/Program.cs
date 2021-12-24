using System;
using System.Collections.Generic;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] armory = new char[n, n];
            int officerPositionRow = -1;
            int officerPositionCol = -1;
            var mirrors = new Queue<int>();

            for (int row = 0; row < n; row++)
            {
                string rows = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    armory[row, col] = rows[col];

                    if (rows[col] == 'A')
                    {
                        officerPositionRow = row;
                        officerPositionCol = col;
                        ReplaceChar(armory, officerPositionRow, officerPositionCol);
                    }

                    if (rows[col] == 'M')
                    {
                        mirrors.Enqueue(row);
                        mirrors.Enqueue(col);
                    }
                }
            }

            int goldCoins  = 0;
            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        officerPositionRow--;
                        break;
                    case "down":
                        officerPositionRow++;
                        break;
                    case "left":
                        officerPositionCol--;
                        break;
                    case "right":
                        officerPositionCol++;
                        break;
                }

                if (IsInTheArmory(armory, officerPositionRow, officerPositionCol))
                {
                    if (armory[officerPositionRow, officerPositionCol] == 'M')
                    {
                        ReplaceChar(armory, officerPositionRow, officerPositionCol);
                        while (mirrors.Count > 0)
                        {
                            int mirrorsRow = mirrors.Dequeue();
                            int mirrorsCol = mirrors.Dequeue();
                            if (mirrorsRow == officerPositionRow && mirrorsCol == officerPositionCol)
                            {
                                officerPositionRow = mirrors.Dequeue();
                                officerPositionCol = mirrors.Dequeue();
                                ReplaceChar(armory, officerPositionRow, officerPositionCol);
                                break;
                            }
                            else
                            {
                                mirrors.Enqueue(mirrorsRow);
                                mirrors.Enqueue(mirrorsCol);
                            }
                        }
                    }
                    else if (armory[officerPositionRow, officerPositionCol] != '-')
                    {
                        goldCoins  += armory[officerPositionRow, officerPositionCol] - '0';
                        if (goldCoins  >= 65)
                        {
                            armory[officerPositionRow, officerPositionCol] = 'A';
                            Console.WriteLine("Very nice swords, I will come back for more!");
                            break;
                        }

                        ReplaceChar(armory, officerPositionRow, officerPositionCol);
                    }
                }
                else
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
            }

            Console.WriteLine($"The king paid {goldCoins} gold coins.");
            PrintMatrix(armory);
        }

        private static void ReplaceChar(char[,] matrix, int myPositionRow, int myPositionCol)
        {
            matrix[myPositionRow, myPositionCol] = '-';
        }

        private static bool IsInTheArmory(char[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1));
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
