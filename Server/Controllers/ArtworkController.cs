using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Models;
using Server.Services.Artwork;
using Shared.Models.Artwork;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/artwork")]

    public class ArtworkController : Controller
    {
        private readonly IArtworkService _artworkService;

        public ArtworkController(IArtworkService artworkService)
        {
            _artworkService = artworkService;
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

            _artworkService.SetUserId(userId);
            return true;
        }


        //CREATE


        [HttpPost("create")]
        public async Task<IActionResult> UploadArtwork(ArtworkCreate model)
        {
            if(model == null) return BadRequest();

            if(!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _artworkService.CreateArtworkMetaDataAsync(model);

            //save the artwork to the database

            if (wasSuccessful) return Ok(new { Message = "Artwork metadata created successfully" });
            else return UnprocessableEntity();
        }

        //UPDATE
    }
}