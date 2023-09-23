using AutoMapper;
using karavana_CONTRACTS.DTOs.Caravan;
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
        }
    }
}
