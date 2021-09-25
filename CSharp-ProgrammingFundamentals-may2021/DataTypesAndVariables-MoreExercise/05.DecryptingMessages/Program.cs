using System;

namespace _05.DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int nCharacters = int.Parse(Console.ReadLine());

            string message = string.Empty;

            for (int i = 0; i < nCharacters; i++)
            {
                message += (char)(char.Parse(Console.ReadLine()) + key);

                //char letters = char.Parse(Console.ReadLine());
                //int number = letters + key;
                //char secretChar = (char)number;
                //message += secretChar;
            }
            Console.WriteLine(message);
        }
    }
}
