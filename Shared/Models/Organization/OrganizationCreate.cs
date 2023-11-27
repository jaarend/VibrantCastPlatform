using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Organization
{
    public class OrganizationCreate
    {
        public int MembershipTypeId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}