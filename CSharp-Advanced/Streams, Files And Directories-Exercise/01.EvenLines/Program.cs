using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("../../../text.txt");
            string[] symbols = new[] { "-", ",", ".", "!", "?" };
            int rowNumbers = 0;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (rowNumbers % 2 == 0)
                {
                    foreach (var symbol in symbols)
                    {
                        line = line.Replace(symbol, "@");
                    }

                    Console.WriteLine(string.Join(" ", line.Split().Reverse()));
                }

                rowNumbers++;
            }
        }
    }
}
