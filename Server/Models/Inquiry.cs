using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VibrantCastPlatform.Server.Models;

namespace Server.Models
{
    public class Inquiry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string FromUserId { get; set; } //the person sending the inquiry
        [Required]
        [ForeignKey("ApplicationUser")]
        public string ToUserId { get; set; } //person receiving the inquiry

        public virtual ApplicationUser Users {get; set;}

        [ForeignKey("Artwork")]
        public int? ArtworkId { get; set; } //can be null if it is not referring to an artwork

        public virtual Artwork? Artwork {get; set;}

        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        //hook up interactions later
        public int InteractionId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateOpened { get; set; }



    }
}