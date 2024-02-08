using Microsoft.AspNetCore.Mvc;
using MusicShop.Models.DTOs;
using MusicShop.Models;
using MusicShop.Services;

namespace MusicShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly IDbService _DbService;

        public ArtistsController(IDbService dbService)
        {
            _DbService = dbService;
        }

        [HttpGet("api/Artist")]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await _DbService.GetArtists();

            return Ok(artists.Select(e => new GetArtistDTO {Name = e.Name }));
        }

        [HttpGet("api/Artist/{artistId}")]
        public async Task<IActionResult> GetArtist(int artistId)
        {
            return NotFound();
        }

        [HttpPost("api/Artist/{artistId}")]
        public async Task<IActionResult> CreateArtist(ArtistDTO artistDTO)
        {
            return NotFound();
        }

        [HttpPut("api/Artist/{artistId}")]
        public async Task<IActionResult> UpdateArtist(int id, ArtistDTO artistDTO)
        {
            return NotFound();
        }

        [HttpDelete("api/Artist/{artistId}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            return NotFound();
        }
    }
}
