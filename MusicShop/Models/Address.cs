using System;
using System.Collections.Generic;

namespace MusicShop.Models;

public partial class Address
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;

    public int Postcode { get; set; }

    public string StreetName { get; set; } = null!;

    public int StreetNumber { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();
}
