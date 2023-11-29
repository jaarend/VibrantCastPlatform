using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Server.Models;
using Shared.Models.Organization;
using VibrantCastPlatform.Server.Data;

namespace Server.Services.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ApplicationDbContext _dbContext;

        private string _userId;

        public OrganizationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SetUserId(string userId) => _userId = userId;


        //CREATE

        public async Task<bool> CreateOrganizationAsync(OrganizationCreate model)
        {
            var entity = new Models.Organization
            {
                MembershipTypeId = model.MembershipTypeId,
                DateCreated = DateTime.Now
            };

            _dbContext.Organizations.Add(entity);

            var orgCheck = await _dbContext.SaveChangesAsync() == 1;

            if (await MapUserToOrgAsync(_userId, entity.Id) && orgCheck)
                return true;
            else
                return false;

        }

        //map user to admin of org

        public async Task<bool> MapUserToOrgAsync(string userId, int orgId)
        {
            var userMapping = new Models.OrganizationUserMapping
            {
                UserId = userId,
                OrganizationId = orgId,
                IsAdmin = true
            };
            _dbContext.OrganizationUserMapping.Add(userMapping);

            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> CreateOrganizationInfoAsync(OrganizationInfoCreate model)
        {
            var selectedOrg = await _dbContext
                .Organizations
                .FirstOrDefaultAsync(s => s.Id == model.Id);

            var entity = new Models.OrgAccountInfo
            {
                Id = model.Id,
                ProfileImage = model.ProfileImage,
                OrganizationName = model.OrganizationName,
                Description = model.Description,
                CommissionPrice = model.CommissionPrice,
                Address = model.Address,
                City = model.City,
                State = model.State,
                Country = model.Country,
                PostalCode = model.PostalCode,
                Website = model.Website,
                Booking = model.Booking,
                Instagram = model.Instagram,
                Facebook = model.Facebook,
                TwitterX = model.TwitterX,
                LinkedIn = model.LinkedIn,
                TikTok = model.TikTok,
                SnapChat = model.SnapChat,
                WhatsApp = model.WhatsApp,
                DateCreated = DateTime.Now
            };

            _dbContext.OrgAccountInfo.Add(entity);

            return await _dbContext.SaveChangesAsync() == 1;
        }

        //READ
        //this is to check if org is created
        public async Task<bool> CheckIfOrgExists(int orgId)
        {
            var entity = await _dbContext
                .Organizations
                .FirstOrDefaultAsync(e => e.Id == orgId);

            if (entity is null)
                return false;
            else
                return true;
        }
        //check if the current user is the admin of an org
        public async Task<OrgUserMappingDetail> CheckOrgUserMapping(string userId)
        {
            var entity = await _dbContext
                .OrganizationUserMapping
                .FirstOrDefaultAsync(e => e.UserId == userId);

            if (entity.IsAdmin == true)
            {
                var detail = new OrgUserMappingDetail
                {
                    UserId = entity.UserId,
                    OrganizationId = entity.OrganizationId,
                    IsAdmin = entity.IsAdmin
                };

                return detail;
            }
            else
                return null;

        }

        public async Task<OrgInfoDetail> GetOrgInfoByIdAsync(int orgId)
        {
            var entity = await _dbContext
                .OrgAccountInfo
                .FirstOrDefaultAsync(e => e.Id == orgId);

            if (entity is null)
                return null;

            var detail = new OrgInfoDetail
            {
                ProfileImage = entity.ProfileImage,
                OrganizationName = entity.OrganizationName,
                Description = entity.Description,
                CommissionPrice = entity.CommissionPrice,
                Address = entity.Address,
                City = entity.City,
                State = entity.State,
                Country = entity.Country,
                PostalCode = entity.PostalCode,
                Website = entity.Website,
                Booking = entity.Booking,
                Instagram = entity.Instagram,
                Facebook = entity.Facebook,
                TwitterX = entity.TwitterX,
                LinkedIn = entity.LinkedIn,
                TikTok = entity.TikTok,
                SnapChat = entity.SnapChat,
                WhatsApp = entity.WhatsApp,
                DateCreated = entity.DateCreated
            };

            return detail;

        }

        public async Task<IEnumerable<OrgInfoDetail>> GetAllOrgInfoAsync()
        {
            var entity = _dbContext
                .OrgAccountInfo
                .Select(n =>
                    new OrgInfoDetail
                    {
                        Id = n.Id,
                        ProfileImage = n.ProfileImage,
                        OrganizationName = n.OrganizationName,
                        Description = n.Description,
                        CommissionPrice = n.CommissionPrice,
                        Address = n.Address,
                        City = n.City,
                        State = n.State,
                        Country = n.Country,
                        PostalCode = n.PostalCode,
                        Website = n.Website,
                        Booking = n.Booking,
                        Instagram = n.Instagram,
                        Facebook = n.Facebook,
                        TwitterX = n.TwitterX,
                        LinkedIn = n.LinkedIn,
                        TikTok = n.TikTok,
                        SnapChat = n.SnapChat,
                        WhatsApp = n.WhatsApp,
                        DateCreated = n.DateCreated
                    });

            return await entity.ToListAsync();
        }

        //UPDATE


        public async Task<bool> EditOrgInfoAsync(OrganizationInfoEdit model)
        {
            if (model == null)
                return false;

            var entity = await _dbContext
                .OrgAccountInfo
                .FirstOrDefaultAsync(n => n.Id == model.Id);

            entity.ProfileImage = model.ProfileImage;
            entity.OrganizationName = model.OrganizationName;
            entity.Description = model.Description;
            entity.CommissionPrice = model.CommissionPrice;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.State = model.State;
            entity.Country = model.Country;
            entity.PostalCode = model.PostalCode;
            entity.Website = model.Website;
            entity.Booking = model.Booking;
            entity.Instagram = model.Instagram;
            entity.Facebook = model.Facebook;
            entity.TwitterX = model.TwitterX;
            entity.LinkedIn = model.LinkedIn;
            entity.TikTok = model.TikTok;
            entity.SnapChat = model.SnapChat;
            entity.WhatsApp = model.WhatsApp;
            entity.DateModified = DateTimeOffset.Now;

            return await _dbContext.SaveChangesAsync() == 1;
        }
        //DELETE
    }
}