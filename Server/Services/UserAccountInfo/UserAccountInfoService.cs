using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
                WhatsApp = model.WhatsApp
            };

            _dbContext.UserAccountInfo.Add(userAccountEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
    }
}