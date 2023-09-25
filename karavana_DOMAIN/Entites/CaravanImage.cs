using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_DOMAIN.Entites
{
    public sealed class CaravanImage : BaseSqlEntity
    {
        public CaravanImage(int caravanId, string imageUrl)
        {
            CaravanId = caravanId;
            ImageUrl = imageUrl;
        }

        public int CaravanId { get; private set; }
        public Caravan Caravan { get; private set; }
        public string ImageUrl { get; private set; }

    }
}
