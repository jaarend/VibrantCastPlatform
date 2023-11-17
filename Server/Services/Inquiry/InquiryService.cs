using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.Inquiry;
using VibrantCastPlatform.Server.Data;

namespace Server.Services.Inquiry
{
    public class InquiryService : IInquiryService
    {
        private readonly ApplicationDbContext _dbContext;

        private string _userId;

        public InquiryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SetUserId(string userId) => _userId = userId;
        public async Task<bool> CreateInquiryAsync(InquiryCreate model)
        {
            var entity = new Models.Inquiry
            {
                FromUserId = model.FromUserId,
                ToUserId = model.ToUserId,
                ArtworkId = model.ArtworkId,
                Title = model.Title,
                Description = model.Description,
                DateCreated = DateTime.Now
            };

            _dbContext.Inquiries.Add(entity);
            
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}