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

        [HttpGet("/Record")]
        public async Task<IActionResult> GetRecords()
        {
            var records = await _DbService.GetRecords();
            return Ok(records.Select(e => GetRecordDTO.MapRecord(e)));
        }
        [HttpGet("/Record/{recordId}")]
        public async Task<IActionResult> GetRecord(int recordId)
        {
            if (!await _DbService.DoesRecordExist(recordId))
                return NotFound($"Record wth given ID - {recordId} does not exists");

            var record = await _DbService.GetRecord(recordId);
            return Ok(GetRecordDTO.MapRecord(record));
        }
        [HttpGet("/Record/Search/{name}")]
        public async Task<IActionResult> GetRecordsByName(string name)
        {
            var RecordsByName = await _DbService.GetRecordsByName(name);
            var RecordsByArtist = await _DbService.GetRecordsByArtistName(name);

            var records = RecordsByName.Union(RecordsByArtist).ToList();

            if (records.IsNullOrEmpty())
                return NotFound("No results for album named: " + name);

            return Ok(records.Select(e => GetRecordDTO.MapRecord(e)));
        }
        [HttpPut("/Record/{recordId}")]
        public async Task<IActionResult> UpdateRecord(int recordId, AddRecordDTO addRecordDTO)
        {
            if (!await _DbService.DoesRecordExist(recordId))
                return NotFound($"Record wth given ID - {recordId} does not exists");
            if (!await _DbService.DoesDistributorExist(addRecordDTO.DistributorId))
                return NotFound($"Distributor with given ID - {addRecordDTO.DistributorId} does not exist");
            if (!await _DbService.DoesTypeOfRecordExist(addRecordDTO.TypeOfRecordId))
                return NotFound($"Type of record with given ID - {addRecordDTO.TypeOfRecordId} does not exist");

            var oldRecord = await _DbService.GetRecord(recordId);

            var artists = new List<Artist>();
            foreach (var artistId in addRecordDTO.ArtistsId)
            {
                if (!await _DbService.DoesArtistExist(artistId))
                    return NotFound($"Artist with given ID - {artistId} does not exist");

                var artist = await _DbService.GetArtist(artistId);

                artists.Add(artist);
            }

            var genres = new List<Genre>();
            foreach (var genreId in addRecordDTO.GenresId)
            {
                if (!await _DbService.DoesArtistExist(genreId))
                    return NotFound($"Genre with given ID - {genreId} does not exist");

                var genre = await _DbService.GetGenre(genreId);

                genres.Add(genre);
            }

            var orderRecords = new List<OrderRecord>();
            
            var record = new Record
            {
                Id = recordId,
                Name = addRecordDTO.Name,
                Price = addRecordDTO.Price,
                Description = addRecordDTO.Description,
                Released = addRecordDTO.Released,
                DistributorId = addRecordDTO.DistributorId,
                Artists = artists,
                Genres = genres,
                Distributor = await _DbService.GetDistributor(addRecordDTO.DistributorId),
                OrderRecords = oldRecord.OrderRecords, 
                RecordStorages = oldRecord.RecordStorages, 
                TypeOfRecordId = addRecordDTO.TypeOfRecordId,
                TypeOfRecord = await _DbService.GetTypeOfRecord(addRecordDTO.TypeOfRecordId)
            };

            await _DbService.UpdateRecord(record);

            return Ok("Succesfuly updated");
        }
        [HttpPost("/Record/{recordId}")]
        public async Task<IActionResult> AddRecord(int recordId, AddRecordDTO addRecordDTO) 
        {
            if(await _DbService.DoesRecordExist(recordId))
                return NotFound($"Record wth given ID - {recordId} already exists");
            if (!await _DbService.DoesDistributorExist(addRecordDTO.DistributorId))
                return NotFound($"Distributor with given ID - {addRecordDTO.DistributorId} does not exist");
            if (!await _DbService.DoesTypeOfRecordExist(addRecordDTO.TypeOfRecordId))
                return NotFound($"Type of record with given ID - {addRecordDTO.TypeOfRecordId} does not exist");
            
            var artists = new List<Artist>();
            foreach (var artistId in addRecordDTO.ArtistsId) 
            {
                if (!await _DbService.DoesArtistExist(artistId))
                    return NotFound($"Artist with given ID - {artistId} does not exist");

                var artist = await _DbService.GetArtist(artistId);

                artists.Add(artist);
            }

            var genres = new List<Genre>();
            foreach (var genreId in addRecordDTO.GenresId)
            {
                if (!await _DbService.DoesArtistExist(genreId))
                    return NotFound($"Genre with given ID - {genreId} does not exist");

                var genre = await _DbService.GetGenre(genreId);

                genres.Add(genre);
            }

            var record = new Record
            {
                Id = recordId,
                Name = addRecordDTO.Name,
                Price = addRecordDTO.Price,
                Description = addRecordDTO.Description,
                Released = addRecordDTO.Released,
                DistributorId = addRecordDTO.DistributorId,
                Artists = artists,
                Genres = genres,
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
