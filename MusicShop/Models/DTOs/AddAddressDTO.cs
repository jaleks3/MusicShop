namespace MusicShop.Models.DTOs
{
    public class AddAddressDTO
    {
        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string State { get; set; } = null!;

        public int Postcode { get; set; }

        public string StreetName { get; set; } = null!;

        public int StreetNumber { get; set; }
    }
}
