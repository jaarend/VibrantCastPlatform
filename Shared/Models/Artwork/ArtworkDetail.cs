using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Artwork
{
    public class ArtworkDetail
    {
        public string CreatorId { get; set; } = null!;

        public string? FullImage { get; set; }

        public string? Title { get; set; }
    
        public string? Description { get; set; }

        public string? Address { get; set; }
 
        public string? City { get; set; }
        
        public string? State { get; set; }
        
        public string? Country { get; set; }
        
        public string? PostalCode { get; set; }

        public string? Materials { get; set; }
        
        public string? Width { get; set; }
        
        public string? Height { get; set; }

        public float? Price { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}