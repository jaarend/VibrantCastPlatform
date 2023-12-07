using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.Organization
{
    public class OrgInfoDetail
    {
        public int Id { get; set; }
        public byte[] ProfileImage { get; set; }
        
        public string OrganizationName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public float CommissionPrice { get; set; }
        
        public string Address { get; set; } = string.Empty;
        
        public string City { get; set; } = string.Empty;
        
        public string State { get; set; } = string.Empty;
        
        public string Country { get; set; } = string.Empty;
        
        public string PostalCode { get; set; } = string.Empty;

        
        public string Website { get; set; } = string.Empty;

        
        public string Booking { get; set; } = string.Empty;
        
        public string Instagram { get; set; } = string.Empty;
        
        public string Facebook { get; set; } = string.Empty;
        
        public string TwitterX { get; set; } = string.Empty;
        
        public string LinkedIn { get; set; } = string.Empty;
        
        public string TikTok { get; set; } = string.Empty;
        
        public string SnapChat { get; set; } = string.Empty;
        
        public string WhatsApp { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }
    }
}