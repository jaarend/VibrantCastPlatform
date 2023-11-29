using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.MediumTags
{
    public class MediumTagEdit
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}