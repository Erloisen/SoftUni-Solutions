using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> vessels;

        public VesselRepository()
        {
            this.vessels = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => this.vessels.AsReadOnly();

        public void Add(IVessel model)
        => this.vessels.Add(model);

        public IVessel FindByName(string name)
        => this.vessels.FirstOrDefault(v => v.Name == name);

        public bool Remove(IVessel model)
        => this.vessels.Remove(model);
    }
}
