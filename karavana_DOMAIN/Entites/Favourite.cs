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
                         int activeCaravanPlaceId)
        {
            UserId = userId;
            ActiveCaravanPlaceId = activeCaravanPlaceId;
        }

        public string UserId { get; private set; }
        public User User { get; private set; }
        public int ActiveCaravanPlaceId { get; private set; }
        public ActiveCaravanPlace ActiveCaravanPlace { get; private set; }
    }
}
