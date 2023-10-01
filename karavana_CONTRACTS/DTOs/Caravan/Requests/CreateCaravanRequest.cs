using karavana_DOMAIN.Entites;
using karavana_DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs.Caravan.Requests
{
    public class CreateCaravanRequest
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public FuelType FuelType { get; init; }
        public CaravanType CaravanType { get; init; }
        public GearType GearType { get; init; }
        public Capacity Capacity { get; init; }
        public int CityId { get; init; }
        public int DistrictId { get; init; }
        public int CompanyId { get; init; }
    }
}
