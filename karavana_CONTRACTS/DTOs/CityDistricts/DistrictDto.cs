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
        public int Id { get; }
        public string DistrictName { get; } = null!;
        public int CityId { get; }
        public CityDto City { get; }
    }
}
