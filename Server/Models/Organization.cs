using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VibrantCastPlatform.Server.Models;

namespace Server.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }

        // [ForeignKey("ApplicationUser")]
        // public string? OrganizationAdminsId { get; set; }

        // [ForeignKey("ApplicationUser")]
        // public string? OrganizationMembersId { get; set; }
        // public virtual ApplicationUser? ApplicationUser { get; set; }


        [Required]
        [ForeignKey("MembershipType")]
        public int MembershipTypeId { get; set; }
        public virtual MembershipType? MembershipType { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
        public virtual ICollection<OrganizationUserMapping> OrganizationUserMapping {get; set;}

        public Organization()
        {
            OrganizationUserMapping = new HashSet<OrganizationUserMapping>();
        }
    }
}