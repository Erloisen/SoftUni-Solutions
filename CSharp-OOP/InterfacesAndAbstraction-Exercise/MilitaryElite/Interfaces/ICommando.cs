using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        public List<IMissions> Missions { get; set; }

        public void CompleteMission(string codeName);
    }
}
