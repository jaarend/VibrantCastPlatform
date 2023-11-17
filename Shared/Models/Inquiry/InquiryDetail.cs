using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Inquiry
{
    public class InquiryDetail
    {
        [Required]
        public string FromUserId { get; set; }
        [Required]
        public string ToUserId { get; set; }
        public int? ArtworkId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTimeOffset? DateOpened { get; set; }
    }
}