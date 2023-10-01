using karavana_DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs.CaravanRentOffer
{
    public class SetCravanOnRentRequest
    {
        public int CaravanId { get; set; }
        public double Price { get; set; } // per day
        public Currency Currency { get; set; }
        public DateTime PlaceStartDate { get; set; }
        public DateTime? PlaceEndDate { get; set; }
    }
}
