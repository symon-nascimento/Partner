using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusActivity
{
    public int Id { get; set; }

    public string Action { get; set; } = null!;

    public Guid? User { get; set; }

    public DateTime Timestamp { get; set; }

    public string? Ip { get; set; }

    public string? UserAgent { get; set; }

    public string Collection { get; set; } = null!;

    public string Item { get; set; } = null!;

    public string? Comment { get; set; }

    public string? Origin { get; set; }

    public virtual ICollection<DirectusRevision> DirectusRevisions { get; set; } = new List<DirectusRevision>();
}
