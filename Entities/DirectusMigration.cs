using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusMigration
{
    public string Version { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime? Timestamp { get; set; }
}
