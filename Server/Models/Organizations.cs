using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Organizations
    {
        [Key]
        public int Id { get; set; }
        public int OrganizationAdminId { get; set; }
        public int OrganizationMembersId { get; set; }

        [Required]
        public int MembershipType { get; set; }

        public virtual OrgAccountInfo OrgAccountInfo {get; set;}

        public int OrgArtworksId { get; set; }

        public int OrgExperiencesId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}