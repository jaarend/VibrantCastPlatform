using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services.MediumTags;
using Shared.Models.MediumTags;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/mediumtag")]
    public class MediumTagController : ControllerBase
    {
        private readonly IMediumTagService _mediumTagService;

        public MediumTagController(IMediumTagService mediumTagService)
        {
            _mediumTagService = mediumTagService;
        }

        //CREATE

        [HttpPost("create")]
        public async Task<IActionResult> CreateMediumTag(MediumTagCreate model)
        {
            if (model == null) return BadRequest();

            bool wasSuccessful = await _mediumTagService.CreateMediumTagAsync(model);

            if (wasSuccessful) return Ok(new { Message = "Medium Tag created successfully" });
            else return UnprocessableEntity();
        }

        //READ

        [HttpGet]
        public async Task<List<MediumTagDetail>> Index()
        {
            var tags = await _mediumTagService.GetAllMediumTagsAsync();

            return tags.ToList();
        }

        //UPDATE

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditMediumTag(int id, MediumTagEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();

            if (model.Id != id) return BadRequest();

            bool wasSuccessful = await _mediumTagService.UpdateMediumTag(model);

            if (wasSuccessful) return Ok();

            return BadRequest();
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _mediumTagService.DeleteMediumTagAsync(id);

            if (tag == false) return NotFound();

            bool wasSuccessful = await _mediumTagService.DeleteMediumTagAsync(id);

            if (!wasSuccessful) return BadRequest();

            return Ok();

        }

    }
}