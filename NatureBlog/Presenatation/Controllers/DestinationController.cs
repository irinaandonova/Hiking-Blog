﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Destinations.Parks.Commands.CreatePark;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatureBlog.Application.Dto.Destination.Park;
using NatureBlog.Application.Dto.Destination.Seaside;
using NatureBlog.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presenatation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        public readonly IMediator _mediator;

        public DestinationController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMostVisited()
        {
            var result = await _mediator.Send(new GetMostVisited());
            return Ok(result);
        }
        /*
        [HttpPost]
        [Route("hiking-trail")]
        public async Task<IActionResult> CreateHikingTrail([FromBody] HikingTrailPostDto hikingTrail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateHikingTrailCommand
            {
                Name = hikingTrail.Name,
                CreatorId = hikingTrail.CreatorId,
                Description = hikingTrail.Description,
                ImageUrl = hikingTrail.ImageUrl,
                RegionId = hikingTrail.RegionId,
                Difficulty = hikingTrail.Difficulty,
                Duration = hikingTrail.Duration
            });

            if (result is null)
                return BadRequest("Invalid input");

            var mappedResult = _mapper.Map<HikingTrailGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("park")]
        public async Task<IActionResult> CreatePark([FromBody] ParkPostDto park)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateParkCommand
            {
                Name = park.Name,
                CreatorId = park.CreatorId,
                Description = park.Description,
                ImageUrl = park.ImageUrl,
                HasPlayground = park.HasPlayground,
                IsDogFriendly = park.IsDogFriendly
            });

            var mappedResult = _mapper.Map<ParkGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("seaside")]
        public async Task<IActionResult> CreateSeaside([FromBody] SeasidePostDto seaside)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateSeasideCommand
            {
                Name = seaside.Name,
                CreatorId = seaside.CreatorId,
                Description = seaside.Description,
                ImageUrl = seaside.ImageUrl,
                OffersUmbrella = seaside.OffersUmbrella,
                IsGuarded = seaside.IsGuarded
            });

            var mappedResult = _mapper.Map<SeasideGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHikingTrail([FromRoute] int hikingTrailId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new GetHikingTrail
            {
                Id = hikingTrailId
            }); 

            return Ok(result);
        }
        }*/
    }
    }
