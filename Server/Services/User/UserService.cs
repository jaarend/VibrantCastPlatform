using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shared.Models.User;
using VibrantCastPlatform.Server.Data;

namespace Server.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private string _userId;

        public void SetUserId(string userId) => _userId = userId;


        public async Task<bool> UpgradeMembership(UserMembershipUpgrade model)
        {

            if (model == null)
                return false;

            var entity = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == _userId);

            if (entity == null || entity.Id != _userId)
                return false;

            entity.MembershipTypeId = model.MembershipTypeId;

            return await _dbContext.SaveChangesAsync() == 1;

        }

        //Get user membershiptype

        public async Task<UserMembershipInfo> GetUserMembership(string userId)
        {
            var entity = await _dbContext
                .Users
                .FirstOrDefaultAsync(e => e.Id == userId);

            if (entity is null)
                return null;

            var detail = new UserMembershipInfo
            {
                MembershipTypeId = entity.MembershipTypeId
            };

            return detail;

        }
    }
}