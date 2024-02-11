using Microsoft.AspNetCore.Mvc;
using MusicShop.Services;

namespace MusicShop.Controllers
{   
    [ApiController]
    [Route("/[controller]")]
    public class OrdersController : ControllerBase
    {
        
        private readonly IDbService _DbService;

        public OrdersController(IDbService dbService)
        {
            _DbService = dbService;
        }

        [HttpGet("/Order")]
        public async Task<IActionResult> GetOrders()
        {
            return NotFound();
        }
    }
}
