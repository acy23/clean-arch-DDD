using karavana_DOMAIN.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs.CityDistricts
{
    public class CityDto
    {
        public int Id { get; set; }
        public string CityName { get; set; } = null!;
    }
}
