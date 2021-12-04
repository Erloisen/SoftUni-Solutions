using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.eggs.AsReadOnly();

        public void Add(IEgg model)
            => this.eggs.Add(model);

        public IEgg FindByName(string name)
            => this.eggs.FirstOrDefault(e => e.Name == name);

        public bool Remove(IEgg model)
            => this.eggs.Remove(model);
    }
}
