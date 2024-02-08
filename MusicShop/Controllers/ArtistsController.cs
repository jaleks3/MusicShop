using Microsoft.AspNetCore.Mvc;
using MusicShop.Models.DTOs;
using MusicShop.Models;
using MusicShop.Services;

namespace MusicShop.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly IDbService _DbService;

        public ArtistsController(IDbService dbService)
        {
            _DbService = dbService;
        }

        [HttpGet("/Artist")]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await _DbService.GetArtists();

            return Ok(artists.Select(e => new GetArtistDTO {Name = e.Name }));
        }

        [HttpGet("/Artist/{artistId}")]
        public async Task<IActionResult> GetArtist(int artistId)
        {
            if(!await _DbService.DoesArtistExist(artistId))
                return NotFound($"Artist with given ID - {artistId} does not exist");

            var artist = await _DbService.GetArtist(artistId);

            return Ok(new GetArtistDTO { Name = artist.Name });
        }

        [HttpPost("/Artist")]
        public async Task<IActionResult> CreateArtist(String name)
        {
            var artist = new Artist { Name = name };

            await _DbService.AddNewArtist(artist);

            return Ok(artist);
        }


        [HttpPut("/Artist/{artistId}")]
        public async Task<IActionResult> UpdateArtist(int id, ArtistDTO artistDTO)
        {
            return NotFound();
        }

        [HttpDelete("/Artist/{artistId}")]
        public async Task<IActionResult> DeleteArtist(int artistId)
        {
            if (!await _DbService.DoesArtistExist(artistId))
                return NotFound($"Artist with given ID - {artistId} does not exist");

            await _DbService.DeleteArtist(artistId);

            return Ok("Succesfuly deleted");
        }
    }
}
