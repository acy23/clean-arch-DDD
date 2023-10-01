using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs.CityDistricts
{
    public class DistrictDto
    {
        public int Id { get; set; }
        public string DistrictName { get; set; } 
        public int CityId { get; set; }
        public CityDto City { get; set; }
    }
}
