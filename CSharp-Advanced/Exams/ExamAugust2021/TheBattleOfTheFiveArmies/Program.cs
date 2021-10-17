using System;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armysArmor = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] map = new char[numberOfRows][];
            int armyRow = -1;
            int armyCol = -1;

            for (int row = 0; row < numberOfRows; row++)
            {
                var currentLine = Console.ReadLine().ToCharArray();
                map[row] = currentLine;
                for (int col = 0; col < map[row].Length; col++)
                {
                    if (map[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }
            
            while (true)
            {
                var command = Console.ReadLine().Split();
                string currentMove = command[0];
                int orcRow = int.Parse(command[1]);
                int orcCol = int.Parse(command[2]);
                map[orcRow][orcCol] = 'O';
                map[armyRow][armyCol] = '-';
                armysArmor--;
                if (currentMove == "up" && armyRow - 1 >= 0)
                {
                    armyRow--;
                }
                else if (currentMove == "down" && armyRow + 1 < numberOfRows)
                {
                    armyRow++;
                }
                else if (currentMove == "left" && armyCol - 1 >= 0 )
                {
                    armyCol--;
                }
                else if (currentMove == "right" && armyCol + 1 < map[armyRow].Length)
                {
                    armyCol++;
                }

                if (map[armyRow][armyCol] == 'O')
                {
                    armysArmor -= 2;
                }
                else if (map[armyRow][armyCol] == 'M')
                {
                    map[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armysArmor}");
                    break;
                }

                if (armysArmor <= 0)
                {
                    map[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }

                map[armyRow][armyCol] = 'A';
            }

            PrintMap(map);
        }

        private static void PrintMap(char[][] map)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", map[row]));
            }
        }
    }
}
