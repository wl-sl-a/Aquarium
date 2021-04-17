using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aquarium.Core.Services;
using Aquarium.Core.Models;
using AutoMapper;
using Aquarium.Resources;
using Microsoft.AspNetCore.Authorization;

namespace Aquarium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : Controller
    {
        private readonly IFishService _musicService;
        private readonly IMapper _mapper;

        public FishController(IFishService musicService, IMapper mapper)
        {
            this._mapper = mapper;
            this._musicService = musicService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<FishResource>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithAqua();
            var musicResources = _mapper.Map<IEnumerable<Fish>, IEnumerable<FishResource>>(musics);

            return Ok(musicResources);
        }
        [HttpPost("")]
        public async Task<ActionResult<FishResource>> CreateMusic([FromBody] FishResource saveMusicResource)
        {

            var musicToCreate = _mapper.Map<FishResource, Fish>(saveMusicResource);

            var newMusic = await _musicService.CreateFish(musicToCreate);

            var music = await _musicService.GetAquaById(newMusic.Id);

            var musicResource = _mapper.Map<Fish, FishResource>(music);

            return Ok(musicResource);
        }
    }
}
