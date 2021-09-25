using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                var lineParts = Console.ReadLine().Split(' ');
                var name = lineParts[0];
                var grade = decimal.Parse(lineParts[1]);
                if (!students.ContainsKey(name))
                {
                    students[name] = new List<decimal>();
                }

                students[name].Add(grade);
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var garde in student.Value)
                {
                    Console.Write($"{garde:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
