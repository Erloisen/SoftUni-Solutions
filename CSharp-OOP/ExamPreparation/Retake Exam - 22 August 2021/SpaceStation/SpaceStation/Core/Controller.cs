using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts = new AstronautRepository();
        private PlanetRepository planets = new PlanetRepository();
        private int deadAstronauts = 0;
        private int exploredPlanetsCount = 0;
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var suitableAstronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();
            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            var planet = planets.FindByName(planetName);

            IMission mission = new Mission();
            mission.Explore(planet, suitableAstronauts);
            exploredPlanetsCount++;

            var deadAstronauts = suitableAstronauts.Where(a => a.Oxygen <= 0).ToList();

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts.Count);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut currentAstronaut = astronauts.FindByName(astronautName);
            if (currentAstronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(currentAstronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
