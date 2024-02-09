using Microsoft.AspNetCore.Mvc;
using MusicShop.Models.DTOs;
using MusicShop.Models;
using MusicShop.Services;
using System.Security.Cryptography.Xml;

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

            return Ok(artists.Select(e => new GetArtistDTO {Name = e.Name, Records = GetRecordDTO.MapRecords(e.Records) }));
        }

        [HttpGet("/Artist/{artistId}")]
        public async Task<IActionResult> GetArtist(int artistId)
        {
            if(!await _DbService.DoesArtistExist(artistId))
                return NotFound($"Artist with given ID - {artistId} does not exist");

            var artist = await _DbService.GetArtist(artistId);

            return Ok(artist);
        }

        [HttpPost("/Artist")]
        public async Task<IActionResult> CreateArtist(String name)
        {
            var artist = new Artist { Name = name };

            await _DbService.AddNewArtist(artist);

            return Ok(new GetArtistDTO { Name = artist.Name });
        }


        [HttpPut("/Artist/{artistId}")]
        public async Task<IActionResult> UpdateArtist(int artistId, AddArtistDTO addArtistDTO)
        {
            if (!await _DbService.DoesArtistExist(artistId))
                return NotFound($"Artist with given ID - {artistId} does not exist");

            var artist = await _DbService.GetArtist(artistId);

            await _DbService.UpdateArtist(new Artist
            {
                Id = artist.Id,
                Name = addArtistDTO.Name,
                Records = artist.Records
            });

            return Ok("Succesfuly updated.");

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
