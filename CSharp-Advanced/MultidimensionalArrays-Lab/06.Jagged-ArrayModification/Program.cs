using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] arrays = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int[] lineParts = ReadArrayFromConsole();
                arrays[i] = new int[lineParts.Length];
                for (int j = 0; j < lineParts.Length; j++)
                {
                    arrays[i][j] = lineParts[j];
                }
            }

            var command = Console.ReadLine().Split(' ');
            var commandName = command[0];
            while (commandName != "END")
            {
                var arrayIndex = int.Parse(command[1]);
                var arrayElement = int.Parse(command[2]);
                var value = int.Parse(command[3]);
                if (arrayIndex < 0 || arrayIndex >= arrays.Length || arrayElement < 0 || arrayElement >= arrays[arrayIndex].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (commandName == "Add")
                {
                    arrays[arrayIndex][arrayElement] += value;
                }
                else if (commandName == "Subtract")
                {
                    arrays[arrayIndex][arrayElement] -= value;
                }

                command = Console.ReadLine().Split(' ');
                commandName = command[0];
            }

            foreach (var array in arrays)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }

        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }
    }
}
