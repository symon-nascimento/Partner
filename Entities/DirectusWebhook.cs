using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class DirectusWebhook
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Method { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool? Data { get; set; }

    public string Actions { get; set; } = null!;

    public string Collections { get; set; } = null!;

    public string? Headers { get; set; }
}
