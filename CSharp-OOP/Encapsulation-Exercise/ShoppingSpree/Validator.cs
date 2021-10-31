using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }

        public static void ThrowIfValueIsNegative(double val)
        {
            if (val < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}
