using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public RecordsController( IDbService recordsService)
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
        [HttpGet("/Records/Search/{name}")]
        public async Task<IActionResult> GetRecordsByName(string name)
        {
            var RecordsByName = await _DbService.GetRecordsByName(name);
            var RecordsByArtist = await _DbService.GetRecordsByArtistName(name);

            var records = RecordsByName.Union(RecordsByArtist).ToList();

            if (records.IsNullOrEmpty())
                return NotFound("No results for album named: " + name);

            return Ok(records.Select(e => GetRecordDTO.MapRecord(e)));
        }
        [HttpPut("/Records/{id}")]
        public async Task<IActionResult> UpdateRecord(int id, GetRecordDTO recordDTO)
        {
            if (!await _DbService.DoesRecordExist(id))
                return NotFound("Record with given ID does not exist");

            var record = await _DbService.GetRecord(id);
            // Update the record properties based on the provided DTO
            // ...
            await _DbService.UpdateRecord(record);

            return Ok(GetRecordDTO.MapRecord(record));
        }

    }
}
