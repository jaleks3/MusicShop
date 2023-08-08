namespace MusicShop.Models.DTOs
{
    public class GetRecordDTO
    {
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Released { get; set; }
        public int Quantity { get; set; }
        public virtual GetDistributorDTO Distributor { get; set; } = null!;
        public virtual ICollection<GetArtistDTO> Artists { get; set; } = new List<GetArtistDTO>();
        public virtual ICollection<GetGenreDTO> Genres { get; set; } = new List<GetGenreDTO>();

        public static GetRecordDTO MapRecord(Record record)
        {
            return new GetRecordDTO
            {
                Name = record.Name,
                Price = record.Price,
                Description = record.Description,
                Released = record.Released,
                Quantity = record.RecordStorages.Where(rs => rs.RecordId == record.Id).Sum(rs => rs.Quantity),
                Distributor = new GetDistributorDTO
                {
                    Name = record.Distributor.Name,
                },
                Artists = record.Artists.Select(artist => new GetArtistDTO
                {
                    Name = artist.Name,
                }).ToList(),
                Genres = record.Genres.Select(genre => new GetGenreDTO
                {
                    Name = genre.Name,
                }).ToList(),
            };
        }
    }
}
