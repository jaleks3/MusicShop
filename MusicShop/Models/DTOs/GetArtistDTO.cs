namespace MusicShop.Models.DTOs
{
    public class GetArtistDTO
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<GetRecordDTO> Records { get; set; } = new List<GetRecordDTO>();
    }
}
