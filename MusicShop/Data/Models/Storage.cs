using System;
using System.Collections.Generic;

namespace MusicShop.Data.Models;

public partial class Storage
{
    public int Id { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<RecordStorage> RecordStorages { get; set; } = new List<RecordStorage>();
}
