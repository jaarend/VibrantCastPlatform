using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Inquiry;
using Shared.Models.Inquiry;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/inquiry")]
    public class InquiryController : ControllerBase
    {
        private readonly IInquiryService _inquiryService;

        public InquiryController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
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

            _inquiryService.SetUserId(userId);
            return true;
        }

        //CREATE

        [HttpPost("create")]
        public async Task<IActionResult> Create(InquiryCreate model)
        {
            if (model == null) return BadRequest();

            if (!SetUserIdInService()) return Unauthorized();

            bool wasSuccessful = await _inquiryService.CreateInquiryAsync(model);

            if (wasSuccessful) return Ok(new { Message = "Inquiry created successfully" });
            else return UnprocessableEntity();
        }

        //READ

        [HttpGet]
        public async Task<List<InquiryDetail>> Index()
        {
            if(!SetUserIdInService()) return new List<InquiryDetail>();

            var inquiries = await _inquiryService.GetAllOwnerInquiriesAsync();

            return inquiries.ToList();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Inquiry(int id)
        {
            if(!SetUserIdInService()) return Unauthorized();

            var inquiry = await _inquiryService.GetInquiryByIdAsync(id);

            if(inquiry == null) return NotFound();

            return Ok(inquiry);
        }
    }
}