using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfoInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] personInfoBeerInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] personInputInfoForBankAcount = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string fullName = personInfoInput[0] + ' ' + personInfoInput[1];
            string address = personInfoInput[2];
            string town = string.Join(" ", personInfoInput.Skip(3));
            
            string name = personInfoBeerInput[0];
            int litersOfBeer = int.Parse(personInfoBeerInput[1]);
            bool isDrunk = personInfoBeerInput[2] == "drunk" ? true : false;


            string personName = personInputInfoForBankAcount[0];
            double accountBalance = double.Parse(personInputInfoForBankAcount[1]);
            string bankName = personInputInfoForBankAcount[2];

            var personInfo = new MyThreeuple<string, string, string>(fullName, address, town);
            var personBeerInfo = new MyThreeuple<string, int, bool>(name, litersOfBeer, isDrunk);
            var personBankInfo = new MyThreeuple<string, double, string>(personName, accountBalance, bankName);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeerInfo);
            Console.WriteLine(personBankInfo);
        }
    }
}
