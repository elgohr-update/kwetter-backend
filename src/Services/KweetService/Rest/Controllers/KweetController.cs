﻿using System;
using System.Threading.Tasks;
using Kwetter.Services.KweetService.Application.Common.Interfaces;
using Kwetter.Services.KweetService.Rest.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kwetter.Services.KweetService.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class KweetController : ControllerBase
    {
        private readonly IKweetService _kweetService;

        public KweetController(IKweetService kweetService)
        {
            _kweetService = kweetService;
        }
        
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateKweetRequest createProfileRequest)
        {
            if (ModelState.IsValid)
            {
                var response = await _kweetService.CreateKweetAsync(new Guid(createProfileRequest.ProfileId), createProfileRequest.Message);
                return response.Success ? new OkObjectResult(response) : StatusCode(500);
            }
            return StatusCode(500);
        }
        
        
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaginated([FromQuery] GetKweetsRequest getKweetsRequest)
        {
            if (ModelState.IsValid)
            {
                var response = await _kweetService.GetPaginatedKweetsByProfile(getKweetsRequest.PageNumber, getKweetsRequest.PageSize, new Guid(getKweetsRequest.ProfileId));
                return response.Success ? new OkObjectResult(response) : new NotFoundResult();
            }
            return StatusCode(500);
        }
    }
}