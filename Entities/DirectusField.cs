using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusField
{
    public int Id { get; set; }

    public string Collection { get; set; } = null!;

    public string Field { get; set; } = null!;

    public string? Special { get; set; }

    public string? Interface { get; set; }

    public string? Options { get; set; }

    public string? Display { get; set; }

    public string? DisplayOptions { get; set; }

    public bool? Readonly { get; set; }

    public bool? Hidden { get; set; }

    public int? Sort { get; set; }

    public string? Width { get; set; }

    public string? Translations { get; set; }

    public string? Note { get; set; }

    public string? Conditions { get; set; }

    public bool? Required { get; set; }

    public string? Group { get; set; }

    public string? Validation { get; set; }

    public string? ValidationMessage { get; set; }
}
