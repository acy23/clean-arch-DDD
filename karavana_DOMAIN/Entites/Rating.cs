using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_DOMAIN.Entites
{
    public sealed class Rating : BaseSqlEntity
    {
        public Rating(
            string userId,
            double rate,
            string? comment,
            int activeCaravanPlaceId)
        {
            UserId = userId;
            Rate = rate;
            Comment = comment;
            ActiveCaravanPlaceId = activeCaravanPlaceId;
        }

        public string UserId { get; private set; }
        public User User { get; private set; }
        public double Rate { get; private set; }
        public string? Comment { get; private set; }
        public ActiveCaravanPlace ActiveCaravanPlace { get; private set; }
        public int ActiveCaravanPlaceId { get; private set; }
    }
}
