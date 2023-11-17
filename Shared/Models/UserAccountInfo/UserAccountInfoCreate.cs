using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.UserAccountInfo
{
    public class UserAccountInfoCreate
    {
        
        [MaxLength(250)]
        public string ArtistName { get; set; } = string.Empty;
        [MaxLength(250)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(250)]
        public string LastName { get; set; } = string.Empty;
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

        public DateTime DateCreated { get; set; }
    }
}