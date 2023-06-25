using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusPanel
{
    public Guid Id { get; set; }

    public Guid Dashboard { get; set; }

    public string? Name { get; set; }

    public string? Icon { get; set; }

    public string? Color { get; set; }

    public bool? ShowHeader { get; set; }

    public string? Note { get; set; }

    public string Type { get; set; } = null!;

    public int PositionX { get; set; }

    public int PositionY { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public string? Options { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserCreated { get; set; }

    public virtual DirectusDashboard DashboardNavigation { get; set; } = null!;

    public virtual DirectusUser? UserCreatedNavigation { get; set; }
}
