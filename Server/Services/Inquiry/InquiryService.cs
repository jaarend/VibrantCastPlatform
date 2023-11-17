using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                FromUserId = _userId,
                ToUserId = model.ToUserId,
                ArtworkId = model.ArtworkId,
                Title = model.Title,
                Description = model.Description,
                DateCreated = DateTime.Now
            };

            _dbContext.Inquiries.Add(entity);

            return await _dbContext.SaveChangesAsync() == 1;
        }

        //READ


        //sent inquiries
        public async Task<IEnumerable<InquiryDetail>> GetAllSentInquiriesAsync()
        {

            //check if the fromuserId matches the logged in user
            var inquiryList = _dbContext
                .Inquiries
                .Where(i => i.FromUserId == _userId)
                .Select(i =>
                    new InquiryDetail
                    {
                        FromUserId = i.FromUserId,
                        ToUserId = i.ToUserId,
                        ArtworkId = i.ArtworkId,
                        Title = i.Title,
                        Description = i.Description,
                        DateCreated = i.DateCreated,
                        DateOpened = i.DateOpened //need a method that opens inquiry
                    });

            return await inquiryList.ToListAsync();
        }

        //receive inquiries

        public async Task<IEnumerable<InquiryDetail>> GetAllReceivedInquiriesAsync()
        {
            var inquiryList = _dbContext
                .Inquiries
                .Where(i => i.ToUserId == _userId)
                .Select(i =>
                    new InquiryDetail
                    {
                        FromUserId = i.FromUserId,
                        ToUserId = i.ToUserId,
                        ArtworkId = i.ArtworkId,
                        Title = i.Title,
                        Description = i.Description,
                        DateCreated = i.DateCreated,
                        DateOpened = i.DateOpened //need a method that opens inquiry
                    });

            return await inquiryList.ToListAsync();
        }

        public async Task<InquiryDetail> GetInquiryByIdAsync(int inquiryId)
        {
            var entity = await _dbContext
                .Inquiries
                .FirstOrDefaultAsync(e => e.Id == inquiryId && e.FromUserId == _userId);

            if (entity is null)
                return null;

            var detail = new InquiryDetail
            {
                FromUserId = entity.FromUserId,
                ToUserId = entity.ToUserId,
                ArtworkId = entity.ArtworkId,
                Title = entity.Title,
                Description = entity.Description,
                DateCreated = entity.DateCreated,
                DateOpened = DateTime.Now //need to create logic to check if there is already an open date
            };

            return detail;
        }
    }
}