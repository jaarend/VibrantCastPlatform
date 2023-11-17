using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VibrantCastPlatform.Server.Models;

namespace Server.Models
{
    public class OrganizationUserMapping
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? UserId {get; set;}
        public ApplicationUser? Users {get; set;}

        [ForeignKey("Organization")]
        public int OrganizationId {get; set;}
        public Organization? Organization {get; set;}

        public bool IsAdmin { get; set; }

    }
}