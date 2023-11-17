using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Inquiry
{
    public class InquiryCreate
    {
        public string ToUserId { get; set; }
        public int? ArtworkId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}