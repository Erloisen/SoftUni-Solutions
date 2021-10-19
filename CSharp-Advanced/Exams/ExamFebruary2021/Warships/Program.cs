using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            char[,] field = new char[fieldSize, fieldSize];
            Queue<string> attacks = new Queue<string>(Console.ReadLine().Split(","));

            int firstPlayerShips = 0;
            int seconPlayerShips = 0;
            int seaMine = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                char[] currentLine = Console.ReadLine().Where(c => !Char.IsWhiteSpace(c)).ToArray();
                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = currentLine[col];

                    if (field[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (field[row, col] == '>')
                    {
                        seconPlayerShips++;
                    }
                    else if (field[row, col] == '#')
                    {
                        seaMine++;
                    }
                }
            }

            int totalCountShips = firstPlayerShips + seconPlayerShips;
            bool isTheProgramStoped = false;
            while (attacks.Count > 0)
            {
                string[] currentAttack = attacks.Dequeue().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int attackRow = int.Parse(currentAttack[0]);
                int attackCol = int.Parse(currentAttack[1]);

                if (!IsValide(field, attackRow, attackCol))
                {
                    continue;
                }

                if (field[attackRow, attackCol] == '<')
                {
                    firstPlayerShips--;
                    field[attackRow, attackCol] = 'X';

                }
                else if (field[attackRow, attackCol] == '>')
                {
                    seconPlayerShips--;
                    field[attackRow, attackCol] = 'X';
                }
                else if (field[attackRow, attackCol] == '#')
                {
                    field[attackRow, attackCol] = 'X';

                    for (int row = attackRow - 1; row <= attackRow + 1; row++)
                    {
                        for (int col = attackCol - 1; col <= attackCol + 1; col++)
                        {
                            if (IsValide(field, row, col))
                            {
                                if (field[row, col] == '<')
                                {
                                    firstPlayerShips--;
                                    field[row, col] = 'X';
                                }
                                else if (field[row, col] == '>')
                                {
                                    seconPlayerShips--;
                                    field[row, col] = 'X';
                                }

                                if (firstPlayerShips == 0 && seconPlayerShips == 0)
                                {
                                    isTheProgramStoped = true;
                                    break;
                                }
                            }
                        }

                        if (firstPlayerShips == 0 || seconPlayerShips == 0)
                        {
                            isTheProgramStoped = true;
                            break;
                        }
                    }
                }

                if (firstPlayerShips == 0 || seconPlayerShips == 0)
                {
                    isTheProgramStoped = true;
                    break;
                }
            }

            if (isTheProgramStoped)
            {
                Console.WriteLine(firstPlayerShips > seconPlayerShips ?
                    $"Player One has won the game! {totalCountShips -= firstPlayerShips} ships have been sunk in the battle." :
                    $"Player Two has won the game! {totalCountShips -= seconPlayerShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {seconPlayerShips} ships left.");
            }
        }

        private static bool IsValide(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
