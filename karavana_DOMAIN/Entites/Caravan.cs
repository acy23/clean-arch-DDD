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
                string name, 
                double price,
                Currency currency,
                FuelType fuelType,
                CaravanType caravanType,
                int cityId,
                int districtId,
                GearType gearType)
        {
            Name = name;
            Price = price;
            Currency = currency;
            FuelType = fuelType;
            CaravanType = caravanType;
            CityId = cityId;
            DistrictId = districtId;
            GearType = gearType;
        }

        public string Name { get; private set; }
        public double Price { get; private set; }
        public Currency Currency { get; private set; }
        public double? Rate { get; private set; }
        public FuelType FuelType { get; private set; }
        public CaravanType CaravanType { get; private set; }
        public GearType GearType { get; private set; }
        public int CityId { get; set; }
        public City City { get; private set; }
        public int DistrictId { get; set; }
        public District District { get; private set; }
        public int CompanyId { get; private set; }
        public Company Company { get; private set; }
    }
}
