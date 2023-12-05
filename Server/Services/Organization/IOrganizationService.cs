using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.Organization;

namespace Server.Services.Organization
{
    public interface IOrganizationService
    {
        void SetUserId(string userId);
        Task<bool> CreateOrganizationAsync(OrganizationCreate model);
        Task<bool> CheckIfOrgExists(int orgId);
        Task<OrgUserMappingDetail> CheckOrgUserMapping(string userId);

        Task<bool> MapAdminUserToOrgAsync(string userId, int orgId);

        Task<bool> MapMemberUserToOrgAsync(OrgUserMappingCreate model);
        Task<bool> CreateOrganizationInfoAsync(OrganizationInfoCreate model);

        Task<IEnumerable<OrgUserMappingDetail>> GetOrgUserMembersMapping(int orgId);
        Task<IEnumerable<OrgInfoDetail>> GetAllOrgInfoAsync();
        Task<OrgInfoDetail> GetOrgInfoByIdAsync(int orgId);

        Task<bool> EditOrgInfoAsync(OrganizationInfoEdit model);

        Task<bool> UpgradeMembership(OrgMembershipUpgrade model);


        Task<bool> DeleteOrgUserMapping(string userId);
    }
}