namespace MusicShop.Models.DTOs
{
    public class AddRecordDTO
    {
        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public string Description { get; set; } = null!;

        public DateTime Released { get; set; }

        public int DistributorId { get; set; }

        public int TypeOfRecordId { get; set; }

        public IEnumerable<int> ArtistsId { get; set; } = new List<int>();

        public IEnumerable<int> GenresId { get; set; } = new List<int>();

        
    }
}
