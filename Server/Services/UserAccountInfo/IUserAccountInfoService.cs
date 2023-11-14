using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.UserAccountInfo;

namespace Server.Services.UserAccountInfo
{
    public interface IUserAccountInfoService
    {
        Task<bool> CreateUserAccountInfoAsync(UserAccountInfoCreate model);

        void SetUserId(string userId);
    }
}