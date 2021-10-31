using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Validator
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;

        public static void ThrowIfNameIsNullOrEmpthy(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("A name should not be empty.");
            }
        }
        public static void ThrowIfStatIsOutOfRange(int number, string name)
        {
            if (number < MinValue || number > MaxValue)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }
    }
}
