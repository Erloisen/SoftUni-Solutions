using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnys;
        private readonly IRepository<IEgg> eggs;
        private readonly IWorkshop currentWorkshop;

        public Controller()
        {
            this.bunnys = new BunnyRepository();
            this.eggs = new EggRepository();
            this.currentWorkshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny currentBunny;
            if (bunnyType == nameof(HappyBunny))
            {
                currentBunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                currentBunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnys.Add(currentBunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye currentColor = new Dye(power);
            var currentBynny = bunnys.FindByName(bunnyName);
            if (currentBynny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            currentBynny.AddDye(currentColor);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg currentEgg = new Egg(eggName, energyRequired);
            eggs.Add(currentEgg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> mostRedyBunnys = bunnys.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy).ToList();
            if (mostRedyBunnys.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg currentEgg = eggs.FindByName(eggName);

            foreach (var bunny in mostRedyBunnys)
            {
                currentWorkshop.Color(currentEgg, bunny);

                if (bunny.Energy <= 0)
                {
                    bunnys.Remove(bunny);
                }

                if (currentEgg.IsDone())
                {
                    break;
                }
            }

            if (currentEgg.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var coloredEggs = eggs.Models.Where(e => e.IsDone()).ToList();

            sb.AppendLine($"{coloredEggs.Count} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in bunnys.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Where(c => !c.IsFinished()).Count()} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
