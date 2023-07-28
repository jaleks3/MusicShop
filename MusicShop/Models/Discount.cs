using System;
using System.Collections.Generic;

namespace MusicShop.Models;

public partial class Discount
{
    public int Id { get; set; }

    public int Percentage { get; set; }

    public int MaxDiscount { get; set; }

    public int MinPrice { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
