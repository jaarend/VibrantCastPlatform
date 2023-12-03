using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Services.User;
using Server.Services.UserAccountInfo;
using Shared.Models.User;
using Shared.Models.UserAccountInfo;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/profile/accountinfo")]
    public class UserAccountInfoController : ControllerBase
    {
        private readonly IUserAccountInfoService _userAccountInfoService;

        private readonly IUserService _userService;

        public UserAccountInfoController(IUserAccountInfoService userAccountInfoService, IUserService userService)
        {
            _userAccountInfoService = userAccountInfoService;
            _userService = userService;
        }

        //may separate this out into user services
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

            _userAccountInfoService.SetUserId(userId);
            return true;
        }
        private bool SetUserIdInUserService()
        {
            var userId = GetUserId();
            if (userId == null)
                return false;

            _userService.SetUserId(userId);
            return true;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(UserAccountInfoCreate model)
        {
            if (model == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _userAccountInfoService.CreateUserAccountInfoAsync(model);

            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }


        //GET
        [HttpGet("{userId}")]
        public async Task<IActionResult> Index(string userId)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var userAccountInfo = await _userAccountInfoService.GetUserAccountInfoByIdAsync(userId);

            if (userAccountInfo == null) return NotFound();

            return Ok(userAccountInfo);
        }

        [HttpGet("public-user/{userId}")]
        public async Task<IActionResult> ArtworkDetail(string userId)
        {
            var userAccountInfo = await _userAccountInfoService.GetUserAccountInfoByIdAsync(userId);

            if (userAccountInfo == null) return NotFound();

            return Ok(userAccountInfo);
        }

        [AllowAnonymous]
        [HttpGet("public-users")]
        public async Task<List<UserAccountInfoDetail>> Index()
        {
            var publicUsers = await _userAccountInfoService.GetAllPublicUsersAsync();

            return publicUsers.ToList();
        }

        [HttpGet("membership-status/{userId}")]
        public async Task<IActionResult> MembershipStatus(string userId)
        {
            if (userId == null) return BadRequest();

            if (!SetUserIdInUserService()) return Unauthorized();

            var membershipDetail = await _userService.GetUserMembership(userId);

            if (membershipDetail != null) return Ok(membershipDetail);
            else return UnprocessableEntity();
        }


        //UPDATE
        [HttpPut]
        public async Task<IActionResult> Edit(UserAccountInfoEdit model)
        {
            if (model == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _userAccountInfoService.EditUserAccountInfoAsync(model);

            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

        //update membership
        [HttpPut("membership-upgrade")]
        public async Task<IActionResult> UpgradeMembership(UserMembershipUpgrade model)
        {
            if (model == null) return BadRequest();

            if (!SetUserIdInUserService()) return Unauthorized();

            bool wasSuccessful = await _userService.UpgradeMembership(model);

            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

    }
}