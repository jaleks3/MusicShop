﻿using System;
using System.Collections.Generic;

namespace MusicShop.Data.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
