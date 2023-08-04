namespace MusicShop.Models.DTOs
{
    public class GetRecordsDTO
    {
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Released { get; set; }
        public virtual GetDistributorDTO Distributor { get; set; } = null!;
        public virtual ICollection<GetArtistDTO> Artists { get; set; } = new List<GetArtistDTO>();
        public virtual ICollection<GetGenreDTO> Genres { get; set; } = new List<GetGenreDTO>();
    }
}
