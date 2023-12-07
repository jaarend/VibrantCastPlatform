using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.MembershipType;

namespace Server.Services.MembershipType
{
    public interface IMembershipTypeService
    {
        void SetUserId(string userId);
        Task<bool> CreateMembershipTypeAsync(MembershipTypeCreate model);
        Task<IEnumerable<MembershipTypeDetail>> GetAllMembershipTypesAsync();
        Task<MembershipTypeDetail> GetMembershipTypeDetailByIdAsync(int membershipId);
        Task<bool> EditMembershipTypeAsync(MembershipTypeEdit model);

        Task<bool> DeleteMembershipTypeAsync(int id);

    }
}