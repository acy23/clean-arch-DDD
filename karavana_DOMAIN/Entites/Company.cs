using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_DOMAIN.Entites
{
    public sealed class Company : BaseSqlEntity 
    {
        public Company(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public ICollection<Caravan> Caravans { get; private set; }

    }
}
