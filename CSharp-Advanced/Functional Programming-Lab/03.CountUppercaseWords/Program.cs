using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(UpperCaseFirstLetter());
            Console.WriteLine(string.Join("\n", text));
        }

        private static Func<string, bool> UpperCaseFirstLetter()
        {
            return word => char.IsUpper(word[0]);
        }
    }
}
