using Microsoft.AspNetCore.Mvc;
using MusicShop.Models;
using MusicShop.Services;

namespace MusicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IDbService _DbService;
        public CustomersController(IDbService dbService)
        {
            _DbService = dbService;
        }
        [HttpGet("/Customer")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            if (!await _DbService.DoesCustomerExist(customerId))
                return NotFound($"Customer wth given ID - {customerId} does not exists");

            var customer = await _DbService.GetCustomer(customerId);

            return Ok(customer);
        }
    }
}
