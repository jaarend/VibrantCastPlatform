﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Server.Models;

namespace VibrantCastPlatform.Server.Models;

public class ApplicationUser : IdentityUser
{
   
    [ForeignKey("MembershipType")]
    public int? MembershipTypeId { get; set; }  = 1; //set to 1 as the default free account
    public virtual MembershipType? MembershipType {get; set;}

    public virtual UserAccountInfo? UserAccountInfo {get; set;}

    [Required]
    public DateTime DateCreated { get; set; }

    public DateTimeOffset? DateModified { get; set; }

    public ICollection<OrganizationUserMapping> UsersInOrganization {get; set;}

    public ApplicationUser()
    {
        UsersInOrganization = new HashSet<OrganizationUserMapping>();
    }
}
