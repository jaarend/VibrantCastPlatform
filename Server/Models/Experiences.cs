using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Experiences
    {
        [Key]
        public int Id { get; set; }

        public string ExperienceUrl { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        public List<ExperienceTypes>? ExperiencesId { get; set; }

        public virtual ExperienceTypes? ExperienceTypes {get; set;}

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}