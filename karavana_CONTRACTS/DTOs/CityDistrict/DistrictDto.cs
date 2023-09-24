using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs.CityDistrict
{
    public class DistrictDto
    {
        public int Id { get; }
        public string DistrictName { get; set;  }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
