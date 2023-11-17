using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.Inquiry;

namespace Server.Services.Inquiry
{
    public interface IInquiryService
    {
        Task<bool> CreateInquiryAsync(InquiryCreate model);
    }
}