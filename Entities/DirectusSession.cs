using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusSession
{
    public string Token { get; set; } = null!;

    public Guid? User { get; set; }

    public DateTime Expires { get; set; }

    public string? Ip { get; set; }

    public string? UserAgent { get; set; }

    public Guid? Share { get; set; }

    public string? Origin { get; set; }

    public virtual DirectusShare? ShareNavigation { get; set; }

    public virtual DirectusUser? UserNavigation { get; set; }
}
