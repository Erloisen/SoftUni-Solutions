using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            var avalibleAstronauts = astronauts.Where(a => a.Oxygen > 0).ToList();

            foreach (var astronaut in avalibleAstronauts)
            {
                while (astronaut.CanBreath && planet.Items.Count > 0)
                {
                    var currentItem = planet.Items.FirstOrDefault();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(currentItem);
                    planet.Items.Remove(currentItem);
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
