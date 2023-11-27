using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Services.MembershipType;
using Shared.Models.MembershipType;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/membershiptype")]
    public class MembershipTypeController : Controller
    {
        private readonly IMembershipTypeService _membershipTypeService;

        public MembershipTypeController(IMembershipTypeService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
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

            _membershipTypeService.SetUserId(userId);
            return true;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMembershipType(MembershipTypeCreate model)
        {
            if (model == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _membershipTypeService.CreateMembershipTypeAsync(model);

            if(wasSuccessful) return Ok(new {Message = "MembershipType created."});

            else return UnprocessableEntity();
        }

        [HttpGet]
        public async Task<List<MembershipTypeDetail>> Index()
        {
            if(!SetUserIdInService()) return new List<MembershipTypeDetail>();

            var membershipTypes = await _membershipTypeService.GetAllMembershipTypesAsync();

            return membershipTypes.ToList();
        }

    }
}