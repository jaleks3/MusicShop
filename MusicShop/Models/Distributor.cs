using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MusicShop.Models;

public partial class Distributor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
