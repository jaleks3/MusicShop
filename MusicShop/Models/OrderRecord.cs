using System;
using System.Collections.Generic;

namespace MusicShop.Models;

public partial class OrderRecord
{
    public int RecordId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Record Record { get; set; } = null!;
}
