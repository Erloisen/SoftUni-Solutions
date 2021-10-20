using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());
            char[][] field = new char[numberOfRows][];

            int marioRow = -1;
            int marioCol = -1;

            for (int row = 0; row < numberOfRows; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            int bowserRow = -1;
            int bowserCol = -1;
            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ');
                char move = char.Parse(commands[0]);
                bowserRow = int.Parse(commands[1]);
                bowserCol = int.Parse(commands[2]);

                field[bowserRow][bowserCol] = 'B';
                field[marioRow][marioCol] = '-';
                lives--;

                if (move == 'W' && marioRow - 1 >= 0)
                {
                    marioRow--;
                }
                else if (move == 'S' && marioRow + 1 < numberOfRows)
                {
                    marioRow++;
                }
                else if (move == 'A' && marioCol - 1 >= 0)
                {
                    marioCol--;
                }
                else if (move == 'D' && marioCol + 1 < field[marioRow].Length)
                {
                    marioCol++;
                }

                if (field[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                }
                else if (field[marioRow][marioCol] == 'P')
                {
                    field[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }

                if (lives <= 0)
                {
                    field[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                field[marioRow][marioCol] = 'M';
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
    }
}
