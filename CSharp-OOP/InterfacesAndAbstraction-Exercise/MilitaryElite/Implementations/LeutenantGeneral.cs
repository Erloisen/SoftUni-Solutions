using MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Implementations
{
    public class LeutenantGeneral : Private, ILieutenantGeneral
    {
        public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            var baseInfo = base.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(baseInfo);
            sb.AppendLine("Privates:");
            foreach (var item in Privates)
            {
                sb.AppendLine($"  {item}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
