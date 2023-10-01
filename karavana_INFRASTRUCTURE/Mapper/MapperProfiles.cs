using AutoMapper;
using karavana_CONTRACTS.DTOs.CaravanRentOffer;
using karavana_CONTRACTS.DTOs.Caravan;
using karavana_CONTRACTS.DTOs.CityDistricts;
using karavana_CONTRACTS.DTOs.Company;
using karavana_CONTRACTS.DTOs.User;
using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_INFRASTRUCTURE.Mapper
{
    internal class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Caravan, CaravanDTO>();
            CreateMap<User, UserDto>();
            CreateMap<City, CityDto>();
            CreateMap<District, DistrictDto>();
            CreateMap<CaravanRentOffer, CaravanRentOfferDto>();
            CreateMap<Company, CompanyDto>();

        }
    }
}
