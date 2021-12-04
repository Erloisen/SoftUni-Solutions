using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && !egg.IsDone() && bunny.Dyes.Count != 0)
            {
                IDye dye = bunny.Dyes.FirstOrDefault();

                egg.GetColored();
                bunny.Work();
                dye.Use();

                if (dye.IsFinished())
                {
                    bunny.Dyes.Remove(dye);
                }
            }
        }
    }
}
