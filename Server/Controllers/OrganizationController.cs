using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Services.Organization;
using Shared.Models.Organization;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/organization")]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        private string GetUserId()
        {
            string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            if (userIdClaim == null)
                return null;
            return userIdClaim;
        }

        private bool SetUserIdInService()
        {
            var userId = GetUserId();
            if (userId == null)
                return false;

            _organizationService.SetUserId(userId);
            return true;
        }

        //CREATE
        [HttpPost("signup")]
        public async Task<IActionResult> CreateOrg(OrganizationCreate model)
        {
            if (model == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _organizationService.CreateOrganizationAsync(model);

            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPost("profile")]
        public async Task<IActionResult> CreateOrgInfo(OrganizationInfoCreate model)
        {
            if (model == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _organizationService.CreateOrganizationInfoAsync(model);

            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPost("add-members")]
        public async Task<IActionResult> AddMemberUserToOrg(OrgUserMappingCreate model)
        {
            if (model == null || model.UserId == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _organizationService.MapMemberUserToOrgAsync(model);

            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }


        //READ

        //check if org exists
        [HttpGet("check/{Id}")]
        public async Task<IActionResult> OrgCheck(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var org = await _organizationService.CheckIfOrgExists(id);

            if (org == false) return NotFound();

            return Ok(org);
        }

        //check if user is admin
        [HttpGet("checkmapping/{userId}")]
        public async Task<IActionResult> OrgUserMappingCheck(string userId)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var mapping = await _organizationService.CheckOrgUserMapping(userId);

            if (mapping == null) return NotFound();

            return Ok(mapping);
        }

        [HttpGet("org-mapped-users/{orgId}")]
        public async Task<List<OrgUserMappingDetail>> GetOrgUserMappingDetailsAsync(int orgId)
        {
            if (!SetUserIdInService()) return new List<OrgUserMappingDetail>();

            var orgMappingDetails = await _organizationService.GetOrgUserMembersMapping(orgId);

            return orgMappingDetails.ToList();
        }

        //get org profile by Id...may replace
        [HttpGet("{orgId}")]
        public async Task<IActionResult> Profile(int orgId)
        {
            //got rid of the check to see if user is logged in, this will be a public endpoint

            var orgAccountDetail = await _organizationService.GetOrgInfoByIdAsync(orgId);

            if (orgAccountDetail == null) return NotFound();

            return Ok(orgAccountDetail);
        }
        //get org by orgName for dashbaord
        [HttpGet("dashboard/{orgName}")]
        public async Task<IActionResult> OrgDetailByName(string orgName)
        {
            //got rid of the check to see if user is logged in, this will be a public endpoint

            var orgAccountDetail = await _organizationService.GetOrgInfoByOrgNameAsync(orgName);

            if (orgAccountDetail == null) return NotFound();

            return Ok(orgAccountDetail);
        }

        [HttpGet("all")]
        public async Task<List<OrgInfoDetail>> Index()
        {
            if (!SetUserIdInService()) return new List<OrgInfoDetail>();

            var orgs = await _organizationService.GetAllOrgInfoAsync();

            return orgs.ToList();
        }

        //UPDATE

        [HttpPut("profile/edit")]
        public async Task<IActionResult> ProfileEdit(OrganizationInfoEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var orgEdit = await _organizationService.EditOrgInfoAsync(model);

            if (orgEdit == false) return NotFound();

            return Ok(orgEdit);

        }

        [HttpPut("membership-upgrade")]
        public async Task<IActionResult> OrgMembershipUpgrade(OrgMembershipUpgrade model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var orgEdit = await _organizationService.UpgradeMembership(model);

            if(orgEdit == false) return NotFound();

            return Ok(orgEdit);
        }

        //DELETE

        //allow members to be delete from an organization
        [HttpDelete("delete-org-user-mapping/{userId}")]
        public async Task<IActionResult> DeleteOrgUserMapping(string userId)
        {
            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _organizationService.DeleteOrgUserMapping(userId);

            if (!wasSuccessful) return BadRequest();

            return Ok();

        }
    }
}