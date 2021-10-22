using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<string> elements = command.Split().Skip(1).ToList();
            ListyIterator<string> iterator = new ListyIterator<string>(elements);

            while (command != "END")
            {
                if (command == "Print")
                {
                    try
                    {
                        iterator.Print();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
                else if (command == "Move")
                {
                    bool result = iterator.Move();
                    Console.WriteLine(result);
                }
                else if (command == "HasNext")
                {
                    bool result = iterator.HasNext();
                    Console.WriteLine(result);
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ", iterator));
                }

                command = Console.ReadLine();
            }
        }
    }
}
