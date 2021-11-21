using System;

namespace _05.Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = { "-1035.77219", "1AFF", "1e-35", "1.29e325" };
            double result;

            foreach (var value in values)
            {
                try
                {
                    result = System.Convert.ToDouble(value);
                    if (double.IsNegativeInfinity(result) || double.IsInfinity(result))
                    {
                        throw new OverflowException();
                    }
                    Console.WriteLine($"Converted from {value} to {result}");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException ofe)
                {
                    Console.WriteLine(ofe.Message);
                }
            }
        }
    }
}
