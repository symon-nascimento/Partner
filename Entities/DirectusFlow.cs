using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusFlow
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Icon { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public string? Trigger { get; set; }

    public string? Accountability { get; set; }

    public string? Options { get; set; }

    public Guid? Operation { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserCreated { get; set; }

    public virtual ICollection<DirectusOperation> DirectusOperations { get; set; } = new List<DirectusOperation>();

    public virtual DirectusUser? UserCreatedNavigation { get; set; }
}
