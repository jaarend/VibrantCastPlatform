using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VibrantCastPlatform.Server.Models;

namespace Server.Models
{
    public class Artwork
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [ForeignKey("ApplicationUser")]
        public string CreatorId { get; set; } = null!;
        public virtual ApplicationUser? Users {get; set;}


        [Required]
        public string FullImage { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;
        [MaxLength(100)]
        public string State { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;
        [MaxLength(100)]
        public string PostalCode { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Materials { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Width { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Height { get; set; } = string.Empty;

        public float Price { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }

        public virtual ICollection<Experience> Experiences { get; set;}
        public virtual ICollection<Collection> Collections {get; set;}

        public virtual ICollection<MediumTag> MediumTags {get; set;}

        public Artwork()
        {
            Experiences = new HashSet<Experience>();
            Collections = new HashSet<Collection>();
            MediumTags = new HashSet<MediumTag>();
        }

    }
}