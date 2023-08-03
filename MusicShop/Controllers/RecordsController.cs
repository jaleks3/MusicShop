using Microsoft.AspNetCore.Mvc;
using MusicShop.Services;

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
            return Ok(records.FirstOrDefault().Name);
        }
    }
}
