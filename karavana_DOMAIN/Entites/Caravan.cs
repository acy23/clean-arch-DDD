using karavana_DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_DOMAIN.Entites
{
    public sealed class Caravan : BaseSqlEntity
    {
        public Caravan(
                int companyId,
                string name, 
                FuelType fuelType,
                CaravanType caravanType,
                Capacity capacity,
                int cityId,
                int districtId,
                GearType gearType,
                string description)
        {
            Name = name;
            CompanyId = companyId;
            FuelType = fuelType;
            CaravanType = caravanType;
            Capacity = capacity;
            CityId = cityId;
            DistrictId = districtId;
            GearType = gearType;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public FuelType FuelType { get; private set; }
        public CaravanType CaravanType { get; private set; }
        public GearType GearType { get; private set; }
        public Capacity Capacity { get; private set; }
        public int CityId { get; private set; }
        public City City { get; private set; }
        public int DistrictId { get; private set; }
        public District District { get; private set; }
        public int CompanyId { get; private set; }
        public Company Company { get; private set; }
        public ICollection<ActiveCaravanPlace> ActiveCaravanPlaces { get; private set; }
        public ICollection<CaravanImage> Images { get; set; }
    }
}
