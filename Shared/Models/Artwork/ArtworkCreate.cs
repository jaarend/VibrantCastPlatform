using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Artwork
{
    public class ArtworkCreate
    {
        public string? CreatorId { get; set; }

        public byte[] FullImage { get; set; }

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
    }
}