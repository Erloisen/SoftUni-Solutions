using MilitaryElite.Enums;
namespace MilitaryElite.Interfaces
{
    public interface IMissions
    {
        public string CodeName { get; set; }

        public State State { get; set; }
    }
}
