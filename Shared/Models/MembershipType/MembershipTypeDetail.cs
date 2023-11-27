using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.MembershipType
{
    public class MembershipTypeDetail
    {
        public string Name { get; set; }  = string.Empty;

        public string Description { get; set; }  = string.Empty;

        public float MonthlyAmount { get; set; }
        public float YearlyAmount { get; set; }

        public int ArtworkLimit { get; set; }
        public int ExperiencesLimit { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }


    }
}