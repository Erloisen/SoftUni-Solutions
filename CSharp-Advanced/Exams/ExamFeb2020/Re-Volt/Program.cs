using System;

namespace Re_Volt
{
    public class Position
    {
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }

        public bool IsSafe(int rowCount, int colCount)
        {
            if (Row < 0|| Col < 0)
            {
                return false;
            }
            if (Row >= rowCount || Col >= rowCount)
            {
                return false;
            }

            return true;
        }

        public void CheckOtherSideMovement(int rowCount, int colCount)
        {
            if (Row < 0)
            {
                Row = rowCount - 1;
            }
            if (Col < 0)
            {
                Col = colCount - 1;
            }
            if (Row >= rowCount - 1)
            {
                Row = 0;
            }
            if (Col >= colCount - 1)
            {
                Col = 0;
            }
        }

        public static Position GetDirection(string command)
        {
            int row = 0;
            int col = 0;
            if (command == "up")
            {
                row--;
            }
            if (command == "down")
            {
                row++;
            }
            if (command == "left")
            {
                col--;
            }
            if (command == "right")
            {
                col++;
            }

            return new Position(row, col);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[][] matrix = new char[matrixSize][];
            ReadMatrix(matrix);
            var player = GetPlayerPosotion(matrix);

            while (countOfCommands != 0)
            {
                var commandLine = Console.ReadLine();
                MovePlayer(player, commandLine, matrixSize);
                
                while (matrix[player.Row][player.Col] == 'B')
                {
                    MovePlayer(player, commandLine, matrixSize);
                }

                while (matrix[player.Row][player.Col] == 'T')
                {
                    Position directoion = Position.GetDirection(commandLine);
                    player.Row += directoion.Row * -1;
                    player.Col += directoion.Col * -1;
                }

                
                if (matrix[player.Row][player.Col] == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[player.Row][player.Col] = 'f';
                    PrintMatrix(matrixSize, matrix);
                    return;
                }

                countOfCommands--; 
            }

            
            Console.WriteLine("Player lost!");
            matrix[player.Row][player.Col] = 'f';
            PrintMatrix(matrixSize, matrix);
        }

        private static void PrintMatrix(int matrixSize, char[][] matrix)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        static Position MovePlayer(Position player, string command, int n)
        {
            Position movements = Position.GetDirection(command);
            player.Row += movements.Row;
            player.Col += movements.Col;
            player.CheckOtherSideMovement(n, n);

            return player;
        }

        public static void ReadMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputLine = Console.ReadLine().ToCharArray();
                matrix[row] = inputLine;
            }
        }

        public static Position GetPlayerPosotion(char[][] matrix)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'f')
                    {
                        position = new Position(row, col);
                    }
                }
            }

            return position;
        }
    }
}
