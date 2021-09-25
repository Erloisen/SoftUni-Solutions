using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeField = int.Parse(Console.ReadLine());
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            char[,] field = new char[sizeField, sizeField];
            int startRow = 0;
            int startCol = 0;
            int collectCoals = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] lines = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = lines[col];

                    if (field[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }

                    if (field[row, col] == 'c')
                    {
                        collectCoals++;
                    }
                }
            }

            while (commands.Count > 0)
            {
                string command = commands.Dequeue();
                switch (command)
                {
                    case "up":
                        ReplaceWithStar(field, startRow, startCol);
                        if (IsInside(field, startRow - 1, startCol))
                        {
                            startRow -= 1;
                            collectCoals = CollectedCoals(field, startRow, startCol, collectCoals);

                            if (field[startRow, startCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        break;
                    case "down":
                        ReplaceWithStar(field, startRow, startCol);
                        if (IsInside(field, startRow + 1, startCol))
                        {
                            startRow += 1;
                            collectCoals = CollectedCoals(field, startRow, startCol, collectCoals);

                            if (field[startRow, startCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        break;
                    case "left":
                        ReplaceWithStar(field, startRow, startCol);
                        if (IsInside(field, startRow, startCol - 1))
                        {
                            startCol -= 1;
                            collectCoals = CollectedCoals(field, startRow, startCol, collectCoals);

                            if (field[startRow, startCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        break;
                    case "right":
                        ReplaceWithStar(field, startRow, startCol);
                        if (IsInside(field, startRow, startCol + 1))
                        {
                            startCol += 1;
                            collectCoals = CollectedCoals(field, startRow, startCol, collectCoals);

                            if (field[startRow, startCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                return;
                            }
                        }
                        break;
                }

                if (collectCoals == 0)
                {
                    break;
                }
            }

            Console.WriteLine(collectCoals == 0 ?
                $"You collected all coals! ({startRow}, {startCol})" :
                $"{collectCoals} coals left. ({startRow}, {startCol})");
        }

        private static int CollectedCoals(char[,] field, int startRow, int startCol, int counter)
        {
            if (field[startRow, startCol] == 'c')
            {
                counter--;
                ReplaceWithStar(field, startRow, startCol);
            }

            return counter;
        }

        private static void ReplaceWithStar(char[,] field, int startRow, int startCol)
        {
            field[startRow, startCol] = '*';
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
