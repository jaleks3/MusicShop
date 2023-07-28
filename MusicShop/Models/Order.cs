using System;
using System.Collections.Generic;

namespace MusicShop.Models;

public partial class Order
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int AddressId { get; set; }

    public int StatusId { get; set; }

    public DateTime RequestAt { get; set; }

    public DateTime FulfillAt { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<OrderRecord> OrderRecords { get; set; } = new List<OrderRecord>();

    public virtual Status Status { get; set; } = null!;
}
