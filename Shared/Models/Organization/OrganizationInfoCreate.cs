using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Organization
{
    public class OrganizationInfoCreate
    {
        public int Id { get; set; }
        public byte[] ProfileImage { get; set; }
        [MaxLength(500)]
        public string OrganizationName { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        public float CommissionPrice { get; set; }
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;
        [MaxLength(100)]
        public string State { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;
        [MaxLength(100)]
        public string PostalCode { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Website { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Booking { get; set; } = string.Empty;
        [MaxLength(250)]
        public string Instagram { get; set; } = string.Empty;
        [MaxLength(250)]
        public string Facebook { get; set; } = string.Empty;
        [MaxLength(250)]
        public string TwitterX { get; set; } = string.Empty;
        [MaxLength(250)]
        public string LinkedIn { get; set; } = string.Empty;
        [MaxLength(250)]
        public string TikTok { get; set; } = string.Empty;
        [MaxLength(250)]
        public string SnapChat { get; set; } = string.Empty;
        [MaxLength(250)]
        public string WhatsApp { get; set; } = string.Empty;

        [Required]
        public DateTime DateCreated { get; set; }
    }
}