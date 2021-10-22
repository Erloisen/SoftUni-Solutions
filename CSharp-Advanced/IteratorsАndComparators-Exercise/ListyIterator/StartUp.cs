using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string comamnd = Console.ReadLine();

            List<string> elements = comamnd.Split().Skip(1).ToList();
            ListyIterator<string> iterator = new ListyIterator<string>(elements);

            while (comamnd != "END")
            {
                if (comamnd == "Print")
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
                else if (comamnd == "Move")
                {
                    bool result = iterator.Move();
                    Console.WriteLine(result);
                }
                else if (comamnd == "HasNext")
                {
                    bool result = iterator.HasNext();
                    Console.WriteLine(result);
                }
                comamnd = Console.ReadLine();
            }
        }
    }
}
