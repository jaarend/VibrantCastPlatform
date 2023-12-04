using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Organization
{
    public class OrgUserMappingDetail
    {
        public string? UserId {get; set;}

        public int OrganizationId {get; set;}

        public bool IsAdmin { get; set; }
    }
}