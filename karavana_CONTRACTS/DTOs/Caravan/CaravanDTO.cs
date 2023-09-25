using karavana_CONTRACTS.DTOs.CityDistricts;
using karavana_CONTRACTS.DTOs.Company;
using karavana_DOMAIN.Entites;
using karavana_DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs.Caravan
{
    public class CaravanDTO : BaseDto
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public FuelType FuelType { get; set; }
        public CaravanType CaravanType { get; set; }
        public GearType GearType { get; set; }
        public Capacity Capacity { get; set; }
        public int CityId { get; set; }
        public CityDto City { get; set; }
        public int DistrictId { get; set; }
        public DistrictDto District { get; set; }
        public CompanyDto Company { get; set; }
    }
}
