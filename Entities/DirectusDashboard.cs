using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusDashboard
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? UserCreated { get; set; }

    public string? Color { get; set; }

    public virtual ICollection<DirectusPanel> DirectusPanels { get; set; } = new List<DirectusPanel>();

    public virtual DirectusUser? UserCreatedNavigation { get; set; }
}
