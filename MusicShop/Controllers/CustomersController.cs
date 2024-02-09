using Microsoft.AspNetCore.Mvc;
using MusicShop.Models;
using MusicShop.Models.DTOs;
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
        [HttpGet("/Customer/{customerId}")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            if (!await _DbService.DoesCustomerExist(customerId))
                return NotFound($"Customer wth given ID - {customerId} does not exists");

            var customer = await _DbService.GetCustomer(customerId);

            return Ok(new AddCustomerDTO
            {
                Name = customer.Name,
                Surname = customer.Surname,
                addAddressDTO = new AddAddressDTO
                {
                    City = customer.Address.City,
                    Country = customer.Address.Country,
                    State = customer.Address.State,
                    Postcode = customer.Address.Postcode,
                    StreetName = customer.Address.StreetName,
                    StreetNumber = customer.Address.StreetNumber,
                }
            });

        }
        [HttpPut("/Customer/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, AddCustomerDTO addCustomerDTO) 
        {
            if (!await _DbService.DoesCustomerExist(customerId))
                return NotFound($"Customer wth given ID - {customerId} does not exists");

            var customer = new Customer
            {
                Name = addCustomerDTO.Name,
                Surname = addCustomerDTO.Surname,
                Address = new Address
                {
                    City = addCustomerDTO.addAddressDTO.City,
                    Country = addCustomerDTO.addAddressDTO.Country,
                    State = addCustomerDTO.addAddressDTO.State,
                    Postcode = addCustomerDTO.addAddressDTO.Postcode,
                    StreetName = addCustomerDTO.addAddressDTO.StreetName,
                    StreetNumber = addCustomerDTO.addAddressDTO.StreetNumber
                }
            };

            await _DbService.UpdateCustomer(customer);
            
            return Ok(customer);
        }
    }
}
