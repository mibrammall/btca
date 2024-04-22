using System;
using System.Collections.Generic;

namespace Api;

public partial class Company
{
    public int CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
