using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class Client
{
    public int Id { get; set; }

    public string? CompanyName { get; set; }

    public string? Alias { get; set; }

    public string? Uin { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
