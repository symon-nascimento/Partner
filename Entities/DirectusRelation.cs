using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusRelation
{
    public int Id { get; set; }

    public string ManyCollection { get; set; } = null!;

    public string ManyField { get; set; } = null!;

    public string? OneCollection { get; set; }

    public string? OneField { get; set; }

    public string? OneCollectionField { get; set; }

    public string? OneAllowedCollections { get; set; }

    public string? JunctionField { get; set; }

    public string? SortField { get; set; }

    public string OneDeselectAction { get; set; } = null!;
}
