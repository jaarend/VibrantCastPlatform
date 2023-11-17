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
            if (model == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _artworkService.CreateArtworkMetaDataAsync(model);

            //save the artwork to the database

            if (wasSuccessful) return Ok(new { Message = "Artwork metadata created successfully" });
            else return UnprocessableEntity();
        }

        //READ

        [HttpGet]
        public async Task<List<ArtworkDetail>> Index()
        {
            if (!SetUserIdInService()) return new List<ArtworkDetail>();

            var artworks = await _artworkService.GetAllArtworkDetailAsync();

            return artworks.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Artwork(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var artwork = await _artworkService.GetArtworkDetailByIdAsync(id);
            
            if(artwork == null) return NotFound();

            return Ok(artwork);
        }

        //UPDATE

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateArtwork(int id, ArtworkUpdate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            if(model.Id != id) return BadRequest();

            bool wasSuccessful = await _artworkService.UpdateArtworkMetaData(model);

            if(wasSuccessful) return Ok();

            return BadRequest();

        }
    }
}