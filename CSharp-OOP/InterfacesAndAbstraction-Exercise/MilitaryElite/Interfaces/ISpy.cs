using System;
namespace MilitaryElite.Interfaces
{
    public interface ISpy : ISoldiers
    {
        public int CodeNumber { get; set; }
    }
}
