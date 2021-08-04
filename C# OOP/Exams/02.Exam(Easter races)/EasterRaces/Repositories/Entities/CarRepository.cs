using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    internal class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.Model == name);
        }
    }
}
