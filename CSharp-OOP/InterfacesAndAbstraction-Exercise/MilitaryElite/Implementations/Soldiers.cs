using MilitaryElite.Interfaces;
namespace MilitaryElite.Implementations
{
    public abstract class Soldiers : ISoldiers
    {
        protected Soldiers(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
