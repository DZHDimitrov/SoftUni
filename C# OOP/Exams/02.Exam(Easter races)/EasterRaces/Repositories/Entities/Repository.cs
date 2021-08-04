using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    internal abstract class Repository<T> : IRepository<T>
    {
        private readonly ICollection<T> models = new List<T>();

        public IReadOnlyCollection<T> Models => (IReadOnlyCollection<T>)this.models;

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
