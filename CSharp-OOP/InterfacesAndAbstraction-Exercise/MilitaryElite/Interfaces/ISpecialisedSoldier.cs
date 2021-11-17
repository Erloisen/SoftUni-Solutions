using MilitaryElite.Enums;

namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; set; }
    }
}
