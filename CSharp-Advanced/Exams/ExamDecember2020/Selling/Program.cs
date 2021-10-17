using System;
using System.Collections.Generic;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] bakery = new char[n, n];
            int myPositionRow = -1;
            int myPositionCol = -1;
            var pillars = new Queue<int>();

            for (int row = 0; row < n; row++)
            {
                string rows = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    bakery[row, col] = rows[col];

                    if (rows[col] == 'S')
                    {
                        myPositionRow = row;
                        myPositionCol = col;
                        ReplaceChar(bakery, myPositionRow, myPositionCol);
                    }

                    if (rows[col] == 'O')
                    {
                        pillars.Enqueue(row);
                        pillars.Enqueue(col);
                    }
                }
            }
            
            int neededMoney = 0;
            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        myPositionRow--;
                        break;
                    case "down":
                        myPositionRow++;
                        break;
                    case "left":
                        myPositionCol--;
                        break;
                    case "right":
                        myPositionCol++;
                        break;
                }

                if (IsInTheBakery(bakery, myPositionRow, myPositionCol))
                {
                    if (bakery[myPositionRow, myPositionCol] == 'O')
                    {
                        ReplaceChar(bakery, myPositionRow, myPositionCol);
                        while (pillars.Count > 0)
                        {
                            int pillarRow = pillars.Dequeue();
                            int pillarCol = pillars.Dequeue();
                            if (pillarRow == myPositionRow && pillarCol == myPositionCol)
                            {
                                myPositionRow = pillars.Dequeue();
                                myPositionCol = pillars.Dequeue();
                                ReplaceChar(bakery, myPositionRow, myPositionCol);
                                break;
                            }
                            else
                            {
                                pillars.Enqueue(pillarRow);
                                pillars.Enqueue(pillarCol);
                            }
                        }
                    }
                    else if (bakery[myPositionRow, myPositionCol] != '-')
                    {
                        neededMoney += bakery[myPositionRow, myPositionCol] - '0';
                        if (neededMoney >= 50)
                        {
                            bakery[myPositionRow, myPositionCol] = 'S';
                            Console.WriteLine("Good news! You succeeded in collecting enough money!");
                            break;
                        }
                        ReplaceChar(bakery, myPositionRow, myPositionCol);
                    }
                }
                else
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }
            }

            Console.WriteLine($"Money: {neededMoney}");
            PrintMatrix(bakery);
        }

        private static void ReplaceChar(char[,] bakery, int myPositionRow, int myPositionCol)
        {
            bakery[myPositionRow, myPositionCol] = '-';
        }

        private static bool IsInTheBakery(char[,] matrix, int row, int col)
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
