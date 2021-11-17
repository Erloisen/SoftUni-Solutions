using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallingOtherPhones
    {
        public void Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
