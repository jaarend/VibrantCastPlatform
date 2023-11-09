using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        public float MonthlyAmount { get; set; }
        public float YearlyAmount { get; set; }

        public int ArtworkLimit { get; set; }
        public int ExperiencesLimit { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }

        
    }
}