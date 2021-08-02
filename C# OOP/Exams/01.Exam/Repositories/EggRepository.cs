using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories.Contracts
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> eggs = new List<IEgg>();
        public IReadOnlyCollection<IEgg> Models => (IReadOnlyCollection<IEgg>)this.eggs;

        public void Add(IEgg model)
        {
            this.eggs.Add(model);
        }

        public IEgg FindByName(string name)
        {
           return this.eggs.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            return this.eggs.Remove(model);
        }
    }
}
