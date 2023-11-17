using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VibrantCastPlatform.Server.Models;

namespace Server.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [ForeignKey("ApplicationUser")]
        public string CreatorId { get; set; } = null!;
        public virtual ApplicationUser? Users {get; set;}

        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public virtual Organization? Organization {get; set;}

        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }

        public virtual ICollection<Artwork> Artworks {get; set;}

        public Collection()
        {
            Artworks = new HashSet<Artwork>();
        }
    }
}