using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Implementations
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMissions>();
        }

        public List<IMissions> Missions { get; set; }

        public void CompleteMission(string codeName)
        {
            var mission = this.Missions.FirstOrDefault(m => m.CodeName == codeName);
            mission.State = State.Finished;
        }

        public override string ToString()
        {
            var baseInfo = base.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (var item in this.Missions)
            {
                sb.AppendLine($"  {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
