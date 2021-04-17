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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AquariumController : Controller
    {
        private readonly IAquaService _aquaService;
        private readonly IMapper _mapper;
        public AquariumController(IAquaService aquaService, IMapper mapper)
        {
            this._mapper = mapper;
            this._aquaService = aquaService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<AquaResources>>> GetAll()
        {
            string iden = User.Identity.Name;
            var aquariums = await _aquaService.GetAll(iden);
            var aquaResources = _mapper.Map<IEnumerable<AquariumM>, IEnumerable<AquaResources>>(aquariums);
            return Ok(aquaResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AquaResources>> GetAquaById(int id)
        {
            string iden = User.Identity.Name;
            var aquarium = await _aquaService.GetAquariumById(id, iden);
            var aquaResource = _mapper.Map<AquariumM, AquaResources>(aquarium);
            return Ok(aquaResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<AquaResources>> CreateAqua([FromBody] AquaResources aquaResources)
        {
            var aquaToCreate = _mapper.Map<AquaResources, AquariumM>(aquaResources);
            string iden = User.Identity.Name;
            aquaToCreate.NameCompany = iden;
            var newAqua = await _aquaService.CreateAquarium(aquaToCreate);
            var aquarium = await _aquaService.GetAquariumById(newAqua.Id, iden);
            var aquaResource = _mapper.Map<AquariumM, AquaResources>(aquarium);
            return Ok(aquaResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAqua(int id)
        {
            string iden = User.Identity.Name;
            var aquarium = await _aquaService.GetAquariumById(id, iden);
            if(aquarium != null) await _aquaService.DeleteAquarium(aquarium);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AquaResources>> UpdateArtist(int id, [FromBody] AquaResources aquaResource)
        {
            string iden = User.Identity.Name;
            var artist = _mapper.Map<AquaResources, AquariumM>(aquaResource);
            await _aquaService.UpdateAquarium(id, artist);

            var updatedArtist = await _aquaService.GetAquariumById(id, iden);
            var updatedArtistResource = _mapper.Map<AquariumM, AquaResources>(updatedArtist);
            return Ok(updatedArtistResource);
        }
    }
}
