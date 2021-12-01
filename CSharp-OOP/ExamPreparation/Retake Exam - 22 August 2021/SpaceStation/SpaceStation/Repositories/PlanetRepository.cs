using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models = new List<IPlanet>();
        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model)
            => models.Add(model);

        public IPlanet FindByName(string name)
            => this.models.FirstOrDefault(p => p.Name == name);

        public bool Remove(IPlanet model)
            => this.models.Remove(model);
    }
}
