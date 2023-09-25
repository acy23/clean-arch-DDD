using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? ChangedAt { get; set; }
        [JsonIgnore]
        public string? ChangedBy { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
