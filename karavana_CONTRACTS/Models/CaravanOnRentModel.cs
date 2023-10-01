using karavana_CONTRACTS.DTOs.CaravanImage;
using karavana_CONTRACTS.DTOs.CaravanRentOffer;
using karavana_CONTRACTS.DTOs.CityDistricts;
using karavana_CONTRACTS.DTOs.Company;
using karavana_DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.Models
{
    public class CaravanOnRentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FuelType FuelType { get; set; }
        public CaravanType CaravanType { get; set; }
        public GearType GearType { get; set; }
        public Capacity Capacity { get; set; }
        public CityDto City { get; set; }
        public DistrictDto District { get; set; }
        public CompanyDto Company { get; set; }
        public List<CaravanImageDto> CaravanImages { get; set; }
        public List<CaravanRentOfferDto> CaravanRentOffers { get; set; }


    }
}
