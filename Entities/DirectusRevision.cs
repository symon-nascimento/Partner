using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusRevision
{
    public int Id { get; set; }

    public int Activity { get; set; }

    public string Collection { get; set; } = null!;

    public string Item { get; set; } = null!;

    public string? Data { get; set; }

    public string? Delta { get; set; }

    public int? Parent { get; set; }

    public virtual DirectusActivity ActivityNavigation { get; set; } = null!;

    public virtual ICollection<DirectusRevision> InverseParentNavigation { get; set; } = new List<DirectusRevision>();

    public virtual DirectusRevision? ParentNavigation { get; set; }
}
