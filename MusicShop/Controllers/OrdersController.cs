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

        [HttpGet("/Order/{orderId]")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            return NotFound();
        }
    }
}
