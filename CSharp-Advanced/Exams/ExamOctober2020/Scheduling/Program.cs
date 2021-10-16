using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (task == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {taskToBeKilled}");
                    Console.WriteLine(string.Join(" ", threads));
                    break;
                }

                if (thread >= task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (thread < task)
                {
                    threads.Dequeue();
                }
            }
        }
    }
}
