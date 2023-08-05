using Microsoft.AspNetCore.Mvc;
using MusicShop.Models;
using MusicShop.Models.DTOs;
using MusicShop.Services;
using System.Linq;

namespace MusicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IDbService _DbService;
        public RecordsController(IDbService recordsService)
        {
            _DbService = recordsService;
        }

        [HttpGet("/Records")]
        public async Task<IActionResult> GetRecords()
        {
            var records = await _DbService.GetRecords();
            return Ok(records.Select(e => GetRecordDTO.MapRecord(e)));
        }
        [HttpGet("/Records/{id}")]
        public async Task<IActionResult> GetRecord(int id)
        {
            if (!await _DbService.DoesRecordExist(id))
                return NotFound("Record with given ID does not exist");

            var record = await _DbService.GetRecord(id);
            return Ok(GetRecordDTO.MapRecord(record));
        }
        [HttpGet("/Records/Search/{query}")]
        public async Task<IActionResult> GetRecordsByName(string query)
        {
            var RecordsByName = await _DbService.GetRecordsByName(query);
            var RecordsByArtist = await _DbService.GetRecordsByArtistName(query);

            var records = RecordsByName.Union(RecordsByArtist).ToList();

            return Ok(records.Select(e => GetRecordDTO.MapRecord(e)));
        }
    }
}
