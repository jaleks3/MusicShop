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

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist(ArtistDTO artistDTO)
        {
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, ArtistDTO artistDTO)
        {
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            return NotFound();
        }
    }
}
