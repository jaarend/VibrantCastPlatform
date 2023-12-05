using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Organization
{
    public class OrgMembershipUpgrade
    {
        public int Id { get; set; }
        public int MembershipTypeId { get; set; }
    }
}