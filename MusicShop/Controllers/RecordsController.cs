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
        public async Task<IActionResult> UpdateRecord(int id, AddRecordDTO addRecordDTO)
        {
            if (!await _DbService.DoesRecordExist(id))
                return NotFound("Record with given ID does not exist");
            if (!await _DbService.DoesDistributorExist(addRecordDTO.DistributorId))
                return NotFound("Distributor with given ID does not exist");
            if (!await _DbService.DoesTypeOfRecordExist(addRecordDTO.TypeOfRecordId))
                return NotFound("Type of record with given ID does not exist");

            var record = new Record
            {
                Id = id,
                Name = addRecordDTO.Name,
                Price = addRecordDTO.Price,
                Description = addRecordDTO.Description,
                Released = addRecordDTO.Released,
                DistributorId = addRecordDTO.DistributorId,
                Distributor = await _DbService.GetDistributor(addRecordDTO.DistributorId),
                OrderRecords = await _DbService.GetOrderRecordsByRecordId(id),
                RecordStorages = await _DbService.GetRecordStoragesByRecordId(id),
                TypeOfRecordId = addRecordDTO.TypeOfRecordId,
                TypeOfRecord = await _DbService.GetTypeOfRecord(addRecordDTO.TypeOfRecordId)
            };

            await _DbService.UpdateRecord(record);

            return NoContent();
        }
        [HttpPost("/Records/{recordId}")]
        public async Task<IActionResult> AddRecord(int recordId, AddRecordDTO addRecordDTO) 
        {
            if(await _DbService.DoesRecordExist(recordId))
                return NotFound($"Record wth given ID - {recordId} already exists");
            if (!await _DbService.DoesDistributorExist(addRecordDTO.DistributorId))
                return NotFound($"Distributor with given ID - {addRecordDTO.DistributorId} does not exist");
            if (!await _DbService.DoesTypeOfRecordExist(addRecordDTO.TypeOfRecordId))
                return NotFound($"Type of record with given ID - {addRecordDTO.TypeOfRecordId} does not exist");

            var record = new Record
            {
                Id = recordId,
                Name = addRecordDTO.Name,
                Price = addRecordDTO.Price,
                Description = addRecordDTO.Description,
                Released = addRecordDTO.Released,
                DistributorId = addRecordDTO.DistributorId,
                Distributor = await _DbService.GetDistributor(addRecordDTO.DistributorId),
                OrderRecords = null,
                RecordStorages = null,
                TypeOfRecordId = addRecordDTO.TypeOfRecordId,
                TypeOfRecord = await _DbService.GetTypeOfRecord(addRecordDTO.TypeOfRecordId)
            };

            await _DbService.AddNewRecord(record);

            return Created("Succesfuly created:",record);
        }
    }
}
