using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Models.UserAccountInfo;
using VibrantCastPlatform.Server.Data;
using VibrantCastPlatform.Server.Models;

namespace Server.Services.UserAccountInfo
{
    public class UserAccountInfoService : IUserAccountInfoService
    {
        private readonly ApplicationDbContext _dbContext;

        private string _userId;

        public UserAccountInfoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SetUserId(string userId) => _userId = userId;

        public async Task<bool> CreateUserAccountInfoAsync(UserAccountInfoCreate model)
        {
            var userAccountEntity = new Models.UserAccountInfo
            {
                Id = _userId,
                ProfileImage = model.ProfileImage,
                ArtistName = model.ArtistName,
                FirstName = model.FirstName,
                LastName = model.LastName,
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

            _dbContext.UserAccountInfo.Add(userAccountEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<UserAccountInfoDetail> GetUserAccountInfoByIdAsync(string userId)
        {
            var userAccountInfoEntity = await _dbContext
                .UserAccountInfo
                .FirstOrDefaultAsync(n => n.Id == userId);

            if (userAccountInfoEntity is null)
                return null;

            var detail = new UserAccountInfoDetail
            {
                ProfileImage = userAccountInfoEntity.ProfileImage,
                ArtistName = userAccountInfoEntity.ArtistName,
                FirstName = userAccountInfoEntity.FirstName,
                LastName = userAccountInfoEntity.LastName,
                Description = userAccountInfoEntity.Description,
                CommissionPrice = userAccountInfoEntity.CommissionPrice,
                Address = userAccountInfoEntity.Address,
                City = userAccountInfoEntity.City,
                State = userAccountInfoEntity.State,
                Country = userAccountInfoEntity.Country,
                PostalCode = userAccountInfoEntity.PostalCode,
                Website = userAccountInfoEntity.Website,
                Booking = userAccountInfoEntity.Booking,
                Instagram = userAccountInfoEntity.Instagram,
                Facebook = userAccountInfoEntity.Facebook,
                TwitterX = userAccountInfoEntity.TwitterX,
                LinkedIn = userAccountInfoEntity.LinkedIn,
                TikTok = userAccountInfoEntity.TikTok,
                SnapChat = userAccountInfoEntity.SnapChat,
                WhatsApp = userAccountInfoEntity.WhatsApp
            };
            return detail;
        }

        //get artist by artist name
        public async Task<UserAccountInfoDetail> GetUserAccountInfoByArtistNameAsync(string artistName)
        {
            var userAccountInfoEntity = await _dbContext
                .UserAccountInfo
                .FirstOrDefaultAsync(n => EF.Functions.Collate(n.ArtistName, "SQL_Latin1_General_CP1_CI_AS") == artistName);

            if (userAccountInfoEntity is null)
                return null;

            var detail = new UserAccountInfoDetail
            {
                Id = userAccountInfoEntity.Id,
                ProfileImage = userAccountInfoEntity.ProfileImage,
                ArtistName = userAccountInfoEntity.ArtistName,
                FirstName = userAccountInfoEntity.FirstName,
                LastName = userAccountInfoEntity.LastName,
                Description = userAccountInfoEntity.Description,
                CommissionPrice = userAccountInfoEntity.CommissionPrice,
                Address = userAccountInfoEntity.Address,
                City = userAccountInfoEntity.City,
                State = userAccountInfoEntity.State,
                Country = userAccountInfoEntity.Country,
                PostalCode = userAccountInfoEntity.PostalCode,
                Website = userAccountInfoEntity.Website,
                Booking = userAccountInfoEntity.Booking,
                Instagram = userAccountInfoEntity.Instagram,
                Facebook = userAccountInfoEntity.Facebook,
                TwitterX = userAccountInfoEntity.TwitterX,
                LinkedIn = userAccountInfoEntity.LinkedIn,
                TikTok = userAccountInfoEntity.TikTok,
                SnapChat = userAccountInfoEntity.SnapChat,
                WhatsApp = userAccountInfoEntity.WhatsApp
            };
            return detail;
        }

        public async Task<IEnumerable<UserAccountInfoDetail>> GetAllPublicUsersAsync()
        {
            var publicUsers = _dbContext
                .UserAccountInfo
                .Select(n =>

                new UserAccountInfoDetail
                {
                    Id = n.Id,
                    ProfileImage = n.ProfileImage,
                    ArtistName = n.ArtistName,
                    FirstName = n.FirstName,
                    LastName = n.LastName,
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
                    WhatsApp = n.WhatsApp
                });

                return await publicUsers.ToListAsync();
        }


        public async Task<bool> EditUserAccountInfoAsync(UserAccountInfoEdit model)
        {
            if (model == null)
                return false;

            var entity = await _dbContext
                .UserAccountInfo
                .FirstOrDefaultAsync(n => n.Id == _userId);

            entity.ProfileImage = model.ProfileImage;
            entity.ArtistName = model.ArtistName;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
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
    }
}