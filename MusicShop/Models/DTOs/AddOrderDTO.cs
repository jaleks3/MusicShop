namespace MusicShop.Models.DTOs
{
    public class AddOrderDTO
    {
        public int Quantity { get; set; }
        public DateTime RequestAt { get; set; }

        public DateTime FulfillAt { get; set; }
        public virtual Address Address { get; set; } = null!;
        public IEnumerable<int> RecordsId { get; set; } = new List<int>();
        public virtual Status Status { get; set; } = null!;
    }
}
