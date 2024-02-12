namespace MusicShop.Models.DTOs
{
    public class AddOrderDTO
    {
        public int CustomerId { get; set; }
        public IEnumerable<int> RecordsId { get; set; } = new List<int>();
    }
}
