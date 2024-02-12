﻿using Microsoft.AspNetCore.Mvc;
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
            var orders = await _DbService.GetOrders(); 

            return Ok(orders);
        }

        [HttpGet("/Order/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            return NotFound();
        }
        [HttpPut("/Order/{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId)
        {
            return NotFound();
        }
        [HttpDelete("/Order/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            return NotFound();
        }
        [HttpPost("/Order/{orderId}")]
        public async Task<IActionResult> AddOrder(int orderId)
        {
            return NotFound();
        }

    }
}
