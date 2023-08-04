using Microsoft.AspNetCore.Mvc;
using MusicShop.Models.DTOs;
using MusicShop.Services;
using System.Linq;

namespace MusicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsService _recordsService;
        public RecordsController(IRecordsService recordsService)
        {
            _recordsService = recordsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecords()
        {
            var records = await _recordsService.GetRecords();
            return Ok(records.Select(e => new GetRecordsDTO
            {
                Name = e.Name,
                Price = e.Price,
                Description = e.Description,
                Released = e.Released,
                Distributor = new GetDistributorDTO
                {
                    Name = e.Distributor.Name,
                },
                Artists = e.Artists.Select(artist => new GetArtistDTO
                {
                    Name = artist.Name,
                }).ToList(),
                Genres = e.Genres.Select(genre => new GetGenreDTO
                {
                    Name = genre.Name,
                }).ToList(),
            }));
        }
    }
}
