using Microsoft.AspNetCore.Mvc;

namespace MusicShop.Models.DTOs
{
    public class AddCustomerDTO
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public virtual AddAddressDTO? addAddressDTO { get; set; } = null!;
    }
}
