using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Implementations
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepairs>();
        }

        public List<IRepairs> Repairs { get; set; }

        public override string ToString()
        {
            var baseInfo = base.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");
            foreach (var item in this.Repairs)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
