using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            char[][] beach = new char[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                char[] inputLine = Console.ReadLine().Where(x => !Char.IsWhiteSpace(x)).ToArray();
                beach[i] = inputLine;
            }

            string commandInfo = Console.ReadLine();
            int myTokens = 0;
            int opponentTokens = 0;
            int row = 0;
            int col = 0;

            while (commandInfo != "Gong")
            {
                string[] action = commandInfo.Split(' ');
                string command = action[0];
                row = int.Parse(action[1]);
                col = int.Parse(action[2]);

                if (!IsValidIndexes(numberOfRows, beach, row, col))
                {
                    commandInfo = Console.ReadLine();
                    continue;
                }

                if (beach[row][col] != 'T')
                {
                    commandInfo = Console.ReadLine();
                    continue;
                }

                if (command == "Find")
                {
                    myTokens++;
                    beach[row][col] = '-';
                }
                else if (command == "Opponent")
                {
                    opponentTokens++;
                    beach[row][col] = '-';
                    string direction = action[3];
                    for (int i = 0; i < 3; i++)
                    {
                        switch (direction)
                        {
                            case "up":
                                row--;
                                break;
                            case "down":
                                row++;
                                break;
                            case "left":
                                col--;
                                break;
                            case "right":
                                col++;
                                break;
                        }

                        if (IsValidIndexes(numberOfRows, beach, row, col) && beach[row][col] == 'T')
                        {
                            opponentTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }

                commandInfo = Console.ReadLine();
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                Console.WriteLine(string.Join(" ", beach[i]));
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static bool IsValidIndexes(int numberOfRows, char[][] beach, int row, int col)
        {
            return (row >= 0 && row < numberOfRows && col >= 0 && col < beach[row].Length);
        }
    }
}
