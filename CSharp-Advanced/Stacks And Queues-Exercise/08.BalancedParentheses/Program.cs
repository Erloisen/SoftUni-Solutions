using System;
using System.Collections.Generic;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parentheses = new Stack<char>();
            bool isBalanced = true;

            foreach (var bracket in input)
            {
                if (bracket == '(' || bracket == '[' || bracket == '{')
                {
                    parentheses.Push(bracket);
                    continue;
                }

                if (parentheses.Count == 0 ||
                    bracket == ')' && parentheses.Pop() != '(' ||
                    bracket == ']' && parentheses.Pop() != '[' ||
                    bracket == '}' && parentheses.Pop() != '{')
                {
                    isBalanced = false;
                    break;
                }

            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
