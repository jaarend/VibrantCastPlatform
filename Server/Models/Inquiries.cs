using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Inquiries
    {
        [Key]
        public int Id { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int ArtworkId { get; set; }

        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int InteractionId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateOpened { get; set; }



    }
}