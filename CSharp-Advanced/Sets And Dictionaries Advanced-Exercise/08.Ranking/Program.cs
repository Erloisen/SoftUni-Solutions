using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var studentsData = new Dictionary<string, Dictionary<string, int>>(); 
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var inputParts = input.Split(':');
                var contest = inputParts[0];
                var password = inputParts[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var inputParts = input.Split("=>");
                var contestName = inputParts[0];
                var password = inputParts[1];
                var participant = inputParts[2];
                var points = int.Parse(inputParts[3]);

                if (!contests.ContainsKey(contestName) || contests[contestName] != (password))
                {
                    continue;
                }

                if (!studentsData.ContainsKey(participant))
                {
                    studentsData.Add(participant, new Dictionary<string, int>());
                }

                if (!studentsData[participant].ContainsKey(contestName))
                {
                    studentsData[participant].Add(contestName, 0);
                }

                if (studentsData[participant][contestName] < points)
                {
                    studentsData[participant][contestName] = points;
                }
            }

            int maxPoints = 0;
            string name = string.Empty;

            foreach (var participant in studentsData)
            {
                if (participant.Value.Sum(x => x.Value) > maxPoints)
                {
                    maxPoints = participant.Value.Sum(x => x.Value);
                    name = participant.Key;
                }
            }

            //var topParticipant = studentsData.OrderByDescending(s => s.Value.Values.Sum(v => v)).FirstOrDefault();

            Console.WriteLine($"Best candidate is {name} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in studentsData.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
