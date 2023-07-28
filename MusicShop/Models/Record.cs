using System;
using System.Collections.Generic;

namespace MusicShop.Models;

public partial class Record
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string Description { get; set; } = null!;

    public DateTime Released { get; set; }

    public int AuthorId { get; set; }

    public int DistributorId { get; set; }

    public int TypeOfRecordId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Distributor Distributor { get; set; } = null!;

    public virtual ICollection<OrderRecord> OrderRecords { get; set; } = new List<OrderRecord>();

    public virtual ICollection<RecordStorage> RecordStorages { get; set; } = new List<RecordStorage>();

    public virtual TypeOfRecord TypeOfRecord { get; set; } = null!;

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
