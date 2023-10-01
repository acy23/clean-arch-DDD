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
        public ICollection<CaravanRentOffer> CaravanRentOffers { get; private set; }
        public ICollection<CaravanImage> Images { get; private set; }

        public void UpdateCaravan(Caravan caravan,
            string? Name,
            string? Description,
            FuelType? FuelType,
            CaravanType? CaravanType,
            GearType? GearType,
            Capacity? Capacity,
            int? CityId,
            int? DistrictId,
            int? CompanyId)
        {
            if (Name != null) { caravan.Name = Name; }

            if (Description != null) { caravan.Description = Description; }

            if (FuelType != null) { caravan.FuelType = FuelType.Value; }

            if (CaravanType != null) {  caravan.CaravanType = CaravanType.Value; }

            if (GearType != null) { caravan.GearType = GearType.Value; }

            if (Capacity != null) { caravan.Capacity = Capacity.Value; }

            if (CityId != null) { caravan.CityId = CityId.Value; }

            if (DistrictId != null) { caravan.DistrictId = DistrictId.Value; }

            if (CompanyId != null) { caravan.CompanyId = CompanyId.Value; }
        }
    
    }
}
