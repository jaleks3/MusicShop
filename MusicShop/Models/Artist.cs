using System;
using System.Collections.Generic;

namespace MusicShop.Models;

public partial class Artist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
