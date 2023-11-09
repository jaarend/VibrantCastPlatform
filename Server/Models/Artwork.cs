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

        [ForeignKey("ApplicantionUser")]
        public string CreatorId { get; set; }
        public virtual ApplicationUser? ApplicationUser {get; set;}

        public List<Collections>? CollectionId { get; set; }

        public virtual Collections? Collections {get; set;}
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

        public List<MediumTags>? MediumTagsId { get; set; }

        public virtual MediumTags? MediumTags { get; set; }

        [MaxLength(500)]
        public string Materials { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Width { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Height { get; set; } = string.Empty;

        public float Price { get; set; }

        public List<Experiences>? ActiveExperiencesId { get; set; }

        public virtual Experiences? Experiences { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }

    }
}