using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.User;

namespace Server.Services.User
{
    public interface IUserService
    {
        void SetUserId(string userId);
        Task<bool> UpgradeMembership(UserMembershipUpgrade model);
    }
}