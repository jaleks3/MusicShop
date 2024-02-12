namespace MusicShop.Models
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
