using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.MediumTags
{
    public class MediumTagListName
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}