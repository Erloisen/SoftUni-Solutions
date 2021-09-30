using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string[] text = File.ReadAllLines("../../../text.txt");

            foreach (var line in File.ReadAllLines("../../../words.txt"))
            {
                if (!wordsCount.ContainsKey(line))
                {
                    wordsCount.Add(line, 0);
                }
            }

            foreach (var line in text)
            {
                foreach (var word in wordsCount)
                {
                    if (line.Contains(word.Key, StringComparison.OrdinalIgnoreCase))
                    {
                        wordsCount[word.Key]++;
                    }
                }
            }

            using StreamWriter writer = new StreamWriter("actualResult.txt");
            foreach (var word in wordsCount.OrderByDescending(x => x.Value))
            {
                writer.WriteLine($"{word.Key} - {word.Value}");
            }

            Console.WriteLine("All is done! Please open the file expectedResult.txt to compare actual and expected results.");
        }
    }
}
