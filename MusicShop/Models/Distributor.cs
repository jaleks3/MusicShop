using System;
using System.Collections.Generic;

namespace MusicShop.Models;

public partial class Distributor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
