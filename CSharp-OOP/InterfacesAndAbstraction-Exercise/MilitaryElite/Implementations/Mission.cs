using MilitaryElite.Enums;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Implementations
{
    public class Mission : IMissions
    {
        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; set; }

        public State State { get; set; }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
