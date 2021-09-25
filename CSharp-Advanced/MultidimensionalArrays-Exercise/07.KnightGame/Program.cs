using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            char[,] board = new char[sizeOfMatrix, sizeOfMatrix];
            FillInBoard(board);

            int removed = 0;

            while (true)
            {
                int maxHitKnight = 0;
                int knightRow = -1;
                int knightCol = -1;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int attacksKnight = HitKnight(board, row, col);

                            if (attacksKnight > maxHitKnight)
                            {
                                maxHitKnight = attacksKnight;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (maxHitKnight > 0)
                {
                    board[knightRow, knightCol] = '0';
                    removed++;
                }
                else if (maxHitKnight == 0)
                {
                    break;
                }
            }

            Console.WriteLine(removed);
        }

        private static int HitKnight(char[,] board, int row, int col)
        {
            int counter = 0;
            if (IsInside(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
            {
                counter++;
            }

            if (IsInside(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
            {
                counter++;
            }

            if (IsInside(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
            {
                counter++;
            }

            if (IsInside(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
            {
                counter++;
            }

            if (IsInside(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
            {
                counter++;
            }

            if (IsInside(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
            {
                counter++;
            }

            if (IsInside(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
            {
                counter++;
            }

            if (IsInside(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
            {
                counter++;
            }

            return counter;
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillInBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] lines = Console.ReadLine().ToCharArray();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = lines[col];
                }
            }
        }
    }
}
