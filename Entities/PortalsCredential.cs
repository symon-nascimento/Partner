using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class PortalsCredential
{
    public int Id { get; set; }

    public string? Uin { get; set; }

    public string? BaseUrl { get; set; }

    public string? Password { get; set; }
}
