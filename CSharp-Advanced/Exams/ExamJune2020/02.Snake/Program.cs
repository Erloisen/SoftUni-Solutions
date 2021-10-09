using System;
using System.Collections.Generic;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];
            var burrows = new Queue<int>();
            int snakeRow = -1;
            int snakeCol = -1;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    territory[i, j] = line[j];
                    if (line[j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                    if (line[j] == 'B')
                    {
                        burrows.Enqueue(i);
                        burrows.Enqueue(j);
                    }
                }
            }

            int foodQuantity = 0;
            while (true)
            {
                string command = Console.ReadLine();
                ReplaceChar(territory, snakeRow, snakeCol);
                switch (command)
                {
                    case "up":
                        snakeRow -= 1;
                        break;
                    case "down":
                        snakeRow += 1;
                        break;
                    case "left":
                        snakeCol -= 1;
                        break;
                    case "right":
                        snakeCol += 1;
                        break;
                }

                if (IsInside(territory, snakeRow, snakeCol))
                {
                    if (territory[snakeRow, snakeCol] == '*')
                    {
                        territory[snakeRow, snakeCol] = 'S';
                        foodQuantity++;
                        if (foodQuantity == 10)
                        {
                            Console.WriteLine("You won! You fed the snake.");
                            Console.WriteLine($"Food eaten: {foodQuantity}");
                            PrintMatrix(territory);
                            break;
                        }

                        ReplaceChar(territory, snakeRow, snakeCol);
                    }
                    else if (territory[snakeRow, snakeCol] == 'B')
                    {
                        while (burrows.Count > 0)
                        {
                            int burrowRow = burrows.Dequeue();
                            int burrowCol = burrows.Dequeue();
                            if (snakeRow == burrowRow && snakeCol == burrowCol)
                            {
                                ReplaceChar(territory, snakeRow, snakeCol);
                                snakeRow = burrows.Dequeue();
                                snakeCol = burrows.Dequeue();
                                break;
                            }
                            else
                            {
                                burrows.Enqueue(burrowRow);
                                burrows.Enqueue(burrowCol);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {foodQuantity}");
                    PrintMatrix(territory);
                    break;
                }
            }
        }

        private static void ReplaceChar(char[,] territory, int snakeRow, int snakeCol)
        {
            territory[snakeRow, snakeCol] = '.';
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
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
