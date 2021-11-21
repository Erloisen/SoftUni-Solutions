using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public double Add(double x, double y, double z)
        {
            return x + y + z;
        }

        public decimal Add(decimal x, decimal y, decimal z)
        {
            return x + y + z;
        }
    }
}
