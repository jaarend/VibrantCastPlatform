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

            if(mapping == null) return NotFound();

            return Ok(mapping);
        }

        //get org profile
        [HttpGet("{orgId}")]
        public async Task<IActionResult> Profile(int orgId)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var userAccountInfo = await _organizationService.GetOrgInfoByIdAsync(orgId);

            if (userAccountInfo == null) return NotFound();

            return Ok(userAccountInfo);
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

            if(orgEdit == false) return NotFound();

            return Ok(orgEdit);

        }
    }
}