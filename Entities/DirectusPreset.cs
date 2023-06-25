using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusPreset
{
    public int Id { get; set; }

    public string? Bookmark { get; set; }

    public Guid? User { get; set; }

    public Guid? Role { get; set; }

    public string? Collection { get; set; }

    public string? Search { get; set; }

    public string? Layout { get; set; }

    public string? LayoutQuery { get; set; }

    public string? LayoutOptions { get; set; }

    public int? RefreshInterval { get; set; }

    public string? Filter { get; set; }

    public string? Icon { get; set; }

    public string? Color { get; set; }

    public virtual DirectusRole? RoleNavigation { get; set; }

    public virtual DirectusUser? UserNavigation { get; set; }
}
