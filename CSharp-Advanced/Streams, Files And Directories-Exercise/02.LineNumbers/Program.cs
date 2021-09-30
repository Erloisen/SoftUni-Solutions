using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] readedLine = File.ReadAllLines("../../../text.txt");
            List<string> text = new List<string>();

            for (int i = 0; i < readedLine.Length; i++)
            {
                int letters = readedLine[i].Count(x => char.IsLetter(x));
                int punctuationMarks = readedLine[i].Count(x => char.IsPunctuation(x));
                text.Add($"Line {i + 1}: {readedLine[i]} ({letters})({punctuationMarks})");
            }

            File.WriteAllLines("output.txt", text);
        }
    }
}
