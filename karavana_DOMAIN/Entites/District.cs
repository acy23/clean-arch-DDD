using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_DOMAIN.Entites
{
    public class District
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int Id { get; private set; }
        public string DistrictName { get; private set; } 
        public int CityId { get; private set; }
        public City City { get; private set; }
        public ICollection<Caravan>? Caravans { get; private set; }
    }
}
