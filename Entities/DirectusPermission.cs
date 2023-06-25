using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusPermission
{
    public int Id { get; set; }

    public Guid? Role { get; set; }

    public string Collection { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string? Permissions { get; set; }

    public string? Validation { get; set; }

    public string? Presets { get; set; }

    public string? Fields { get; set; }

    public virtual DirectusRole? RoleNavigation { get; set; }
}
