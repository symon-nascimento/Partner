using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusShare
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Collection { get; set; }

    public string? Item { get; set; }

    public Guid? Role { get; set; }

    public string? Password { get; set; }

    public Guid? UserCreated { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public int? TimesUsed { get; set; }

    public int? MaxUses { get; set; }

    public virtual DirectusCollection? CollectionNavigation { get; set; }

    public virtual ICollection<DirectusSession> DirectusSessions { get; set; } = new List<DirectusSession>();

    public virtual DirectusRole? RoleNavigation { get; set; }

    public virtual DirectusUser? UserCreatedNavigation { get; set; }
}
