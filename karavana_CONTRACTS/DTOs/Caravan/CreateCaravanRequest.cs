using karavana_DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs.Caravan
{
    public class CreateCaravanRequest
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Currency Currency { get; set; }
        public FuelType FuelType { get; set; }
        public CaravanType CaravanType { get; set; }
        public Capacity Capacity { get; set; }
        public GearType GearType { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
    }
}
