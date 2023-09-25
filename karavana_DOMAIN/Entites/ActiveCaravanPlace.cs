using karavana_DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_DOMAIN.Entites
{
    public sealed class ActiveCaravanPlace : BaseSqlEntity // Aktif ilanda olan karavanlar 
    {
        public ActiveCaravanPlace(
            int caravanId,
            double price,
            Currency currency,
            DateTime placeStartDate,
            DateTime? placeEndDate)
        {
            CaravanId = caravanId;
            Price = price;
            Currency = currency;    
            PlaceStartDate = placeStartDate;
            PlaceEndDate = placeEndDate;
        }

        public int CaravanId { get; private set; }
        public Caravan Caravan { get; private set; }
        public double Price { get; private set; } // per day
        public Currency Currency { get; private set; }
        public DateTime PlaceStartDate { get; private set; }
        public DateTime? PlaceEndDate { get; private set; }
        public ICollection<Favourite> Favourites { get; private set; }
        public ICollection<Rating> Ratings { get; private set; }
    }
}
