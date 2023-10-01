using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_DOMAIN.Entites
{
    public sealed class Favourite : BaseSqlEntity
    {
        public Favourite(string userId,
                         int caravanRentOfferId)
        {
            UserId = userId;
            CaravanRentOfferId = caravanRentOfferId;
        }

        public string UserId { get; private set; }
        public User User { get; private set; }
        public int CaravanRentOfferId { get; private set; }
        public CaravanRentOffer CaravanRentOffer { get; private set; }
    }
}
