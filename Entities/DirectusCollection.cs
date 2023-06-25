using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusCollection
{
    public string Collection { get; set; } = null!;

    public string? Icon { get; set; }

    public string? Note { get; set; }

    public string? DisplayTemplate { get; set; }

    public bool? Hidden { get; set; }

    public bool? Singleton { get; set; }

    public string? Translations { get; set; }

    public string? ArchiveField { get; set; }

    public bool? ArchiveAppFilter { get; set; }

    public string? ArchiveValue { get; set; }

    public string? UnarchiveValue { get; set; }

    public string? SortField { get; set; }

    public string? Accountability { get; set; }

    public string? Color { get; set; }

    public string? ItemDuplicationFields { get; set; }

    public int? Sort { get; set; }

    public string? Group { get; set; }

    public string Collapse { get; set; } = null!;

    public virtual ICollection<DirectusShare> DirectusShares { get; set; } = new List<DirectusShare>();

    public virtual DirectusCollection? GroupNavigation { get; set; }

    public virtual ICollection<DirectusCollection> InverseGroupNavigation { get; set; } = new List<DirectusCollection>();
}
