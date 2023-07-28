using System;
using System.Collections.Generic;

namespace MusicShop.Models;

public partial class RecordStorage
{
    public int RecordId { get; set; }

    public int StorageId { get; set; }

    public int Quantity { get; set; }

    public virtual Record Record { get; set; } = null!;

    public virtual Storage Storage { get; set; } = null!;
}
