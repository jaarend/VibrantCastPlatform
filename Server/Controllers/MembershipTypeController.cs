using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Services.MembershipType;
using Shared.Models.MembershipType;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/membershiptype")]
    [Authorize]
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

        //CREATE

        [HttpPost("create")]
        public async Task<IActionResult> CreateMembershipType(MembershipTypeCreate model)
        {
            if (model == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _membershipTypeService.CreateMembershipTypeAsync(model);

            if (wasSuccessful) return Ok(new { Message = "MembershipType created." });

            else return UnprocessableEntity();
        }


        //READ
        [HttpGet]
        public async Task<List<MembershipTypeDetail>> Index()
        {
            if (!SetUserIdInService()) return new List<MembershipTypeDetail>();

            var membershipTypes = await _membershipTypeService.GetAllMembershipTypesAsync();

            return membershipTypes.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MembershipType(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var artwork = await _membershipTypeService.GetMembershipTypeDetailByIdAsync(id);

            if (artwork == null) return NotFound();

            return Ok(artwork);
        }

        //UPDATE
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, MembershipTypeEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            if (model.Id != id) return BadRequest();

            bool wasSuccessful = await _membershipTypeService.EditMembershipTypeAsync(model);

            if (wasSuccessful) return Ok();

            return BadRequest();

        }

        //DELETE

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _membershipTypeService.DeleteMembershipTypeAsync(id);

            if (wasSuccessful) return Ok();

            return BadRequest();
        }

    }
}