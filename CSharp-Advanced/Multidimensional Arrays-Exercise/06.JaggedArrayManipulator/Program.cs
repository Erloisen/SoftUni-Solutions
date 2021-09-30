using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[n][];

            for (int i = 0; i < n; i++)
            {
                double[] sequences = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedArray[i] = sequences;
                
                if (i > 0)
                {
                    if (jaggedArray[i].Length == jaggedArray[i - 1].Length)
                    {
                        for (int j = 0; j < jaggedArray[i].Length; j++)
                        {
                            jaggedArray[i - 1][j] *= 2;
                            jaggedArray[i][j] *= 2;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < jaggedArray[i - 1].Length; j++)
                        {
                            jaggedArray[i - 1][j] /= 2;
                        }
                        for (int k = 0; k < jaggedArray[i].Length; k++)
                        {
                            jaggedArray[i][k] /= 2;
                        }
                    }
                }
            }

            string[] commands = Console.ReadLine().Split(' ');

            while (commands[0] != "End")
            {
                switch (commands[0])
                {
                    case "Add":
                        int row = int.Parse(commands[1]);
                        int column = int.Parse(commands[2]);
                        double value = double.Parse(commands[3]);
                        if (IsValidIndex(jaggedArray, row, column))
                        {
                            jaggedArray[row][column] += value;
                        }
                        break;

                    case "Subtract":
                        row = int.Parse(commands[1]);
                        column = int.Parse(commands[2]);
                        value = double.Parse(commands[3]);
                        if (IsValidIndex(jaggedArray, row, column))
                        {
                            jaggedArray[row][column] -= value;
                        }
                        break;
                }

                commands = Console.ReadLine().Split(' ');
            }

            foreach (var eachRow in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", eachRow));
            }
        }
        private static bool IsValidIndex(double[][] jaggedArray, int row, int column)
        {
            if (row >= 0 && row < jaggedArray.Length)
            {
                if (column >= 0 && column < jaggedArray[row].Length) return true;
                return false;
            }
            else return false;
        }
    }
}
