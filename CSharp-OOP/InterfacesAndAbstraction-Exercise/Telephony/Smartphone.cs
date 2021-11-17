using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallingOtherPhones, IBrowsingWWW
    {
        public void Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {number}");
        }

        public void Brows(string url)
        {
            if (url.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {url}!");
        }

    }
}
