using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        //add FK relationship
        public string CreatorId {get; set;}

        //add FK relationship

        public int OrgOwnerId {get; set;}

        public string ExperienceUrl { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [ForeignKey("ExperienceType")]
        public int ExperienceTypeId { get; set; }
        public virtual ExperienceType? ExperienceType {get; set;}

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
        public virtual ICollection<Artwork> Artworks { get; set;}

        public Experience()
        {
            Artworks = new HashSet<Artwork>();
        }
    }
}