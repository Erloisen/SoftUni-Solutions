using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunnys;

        public BunnyRepository()
        {
            this.bunnys = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.bunnys.AsReadOnly();

        public void Add(IBunny model)
            => this.bunnys.Add(model);

        public IBunny FindByName(string name)
            => this.bunnys.FirstOrDefault(b => b.Name == name);

        public bool Remove(IBunny model)
            => this.bunnys.Remove(model);
    }
}
