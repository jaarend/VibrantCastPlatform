using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services.UserAccountInfo;
using Shared.Models.UserAccountInfo;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/profile/accountinfo")]
    public class UserAccountInfoController : ControllerBase
    {
        private readonly IUserAccountInfoService _userAccountInfoService;

        public UserAccountInfoController(IUserAccountInfoService userAccountInfoService)
        {
            _userAccountInfoService = userAccountInfoService;
        }

        //may separate this out into user services
        private string GetUserId()
        {
            string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            if(userIdClaim == null)
                return null;
            return userIdClaim;
        }

        private bool SetUserIdInService()
        {
            var userId = GetUserId();
            if(userId == null)
                return false;
        
            _userAccountInfoService.SetUserId(userId);
            return true;
        }

        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create(UserAccountInfoCreate model)
        {
            if(model == null) return BadRequest();

            if(!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _userAccountInfoService.CreateUserAccountInfoAsync(model);

            if(wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }


        //GET
        [HttpGet("/api/profile/{userId}")]
        public async Task<IActionResult> Index(string userId)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var userAccountInfo = await _userAccountInfoService.GetUserAccountInfoByIdAsync(userId);

            if(userAccountInfo == null) return NotFound();

            return Ok(userAccountInfo);
        }


        //UPDATE
        [HttpPut]
        public async Task<IActionResult> Edit(UserAccountInfoEdit model)
        {
            if(model == null) return BadRequest();

            if(!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _userAccountInfoService.EditUserAccountInfoAsync(model);

            if(wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

    }
}