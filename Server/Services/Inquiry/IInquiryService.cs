using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.Inquiry;

namespace Server.Services.Inquiry
{
    public interface IInquiryService
    {
        void SetUserId(string userId);
        Task<bool> CreateInquiryAsync(InquiryCreate model);
        Task<IEnumerable<InquiryDetail>> GetAllOwnerInquiriesAsync();

        Task<InquiryDetail> GetInquiryByIdAsync(int inquiryId);
    }
}