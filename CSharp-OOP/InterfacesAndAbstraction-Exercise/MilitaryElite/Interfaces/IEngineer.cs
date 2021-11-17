using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public List<IRepairs> Repairs { get; set; }
    }
}
