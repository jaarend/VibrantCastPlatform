using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Artwork
{
    public class ArtworkFileUpdate
    {
        public string CreatorId { get; set; } = null!;

        public string FullImage { get; set; } = string.Empty;
    }
}