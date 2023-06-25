using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusRole
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public string? Description { get; set; }

    public string? IpAccess { get; set; }

    public bool? EnforceTfa { get; set; }

    public bool? AdminAccess { get; set; }

    public bool? AppAccess { get; set; }

    public virtual ICollection<DirectusPermission> DirectusPermissions { get; set; } = new List<DirectusPermission>();

    public virtual ICollection<DirectusPreset> DirectusPresets { get; set; } = new List<DirectusPreset>();

    public virtual ICollection<DirectusShare> DirectusShares { get; set; } = new List<DirectusShare>();

    public virtual ICollection<DirectusUser> DirectusUsers { get; set; } = new List<DirectusUser>();
}
