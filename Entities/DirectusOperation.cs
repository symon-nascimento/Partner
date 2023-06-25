using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusOperation
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string Key { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int PositionX { get; set; }

    public int PositionY { get; set; }

    public string? Options { get; set; }

    public Guid? Resolve { get; set; }

    public Guid? Reject { get; set; }

    public Guid Flow { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserCreated { get; set; }

    public virtual DirectusFlow FlowNavigation { get; set; } = null!;

    public virtual DirectusOperation? InverseRejectNavigation { get; set; }

    public virtual DirectusOperation? InverseResolveNavigation { get; set; }

    public virtual DirectusOperation? RejectNavigation { get; set; }

    public virtual DirectusOperation? ResolveNavigation { get; set; }

    public virtual DirectusUser? UserCreatedNavigation { get; set; }
}
