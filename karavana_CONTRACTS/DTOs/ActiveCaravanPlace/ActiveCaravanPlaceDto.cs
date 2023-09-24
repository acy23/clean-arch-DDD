using karavana_CONTRACTS.DTOs.Caravan;
using karavana_DOMAIN.Entites;
using karavana_DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs.ActiveCaravanPlace
{
    public class ActiveCaravanPlaceDto : BaseDto
    {
        public int CaravanId { get; set; }
        public CaravanDTO Caravan { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
        public DateTime PlaceStartDate { get; set; }
        public DateTime? PlaceEndDate { get; set; }
    }
}
