using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sonsgs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> playlist = new Queue<string>(sonsgs);
            string command = Console.ReadLine();

            while (playlist.Count > 0)
            {
                if (command == "Play")
                {
                    playlist.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string song = command.Substring(4);

                    if (!playlist.Contains(song))
                    {
                        playlist.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine($"{string.Join(", ", playlist)}");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
