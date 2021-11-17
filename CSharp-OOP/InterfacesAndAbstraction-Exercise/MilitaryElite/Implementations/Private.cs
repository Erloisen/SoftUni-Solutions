using MilitaryElite.Interfaces;

namespace MilitaryElite.Implementations
{
    public class Private : Soldiers, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}";
        }
    }
}
